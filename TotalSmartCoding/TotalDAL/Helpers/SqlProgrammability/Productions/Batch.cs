using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Productions
{
    public class Batch
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public Batch(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetBatchIndexes();

            this.GetPendingLots();

            this.BatchEditable();
            this.BatchPostSaveValidate();

            this.BatchToggleApproved();
            this.BatchToggleVoid();

            this.BatchInitReference(); //NOT USE THIS ANY MORE. NOW: Reference = Code + LotCode

            this.BatchAddLot();
            this.BatchCommonUpdate();
        }


        private void GetBatchIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @FillingLineID int, @ActiveOption int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Batches.BatchID, CAST(Batches.EntryDate AS DATE) AS EntryDate, Batches.Reference, Batches.Code AS BatchCode, Batches.LotCode, Batches.FillingLineID, Batches.CommodityID, Commodities.Code AS CommodityCode, Commodities.OfficialCode AS CommodityOfficialCode, Commodities.Name AS CommodityName, Commodities.APICode AS CommodityAPICode, Commodities.CartonCode AS CommodityCartonCode, Commodities.Volume, Commodities.PackPerCarton, Commodities.CartonPerPallet, Commodities.Shelflife, " + "\r\n";
            queryString = queryString + "                   BatchTypes.Code AS BatchTypeCode, BatchTypes.Code + '-' + BatchTypes.Name AS BatchTypeCodeName, Batches.NextPackNo, Batches.NextCartonNo, Batches.NextPalletNo, Batches.Description, Batches.Remarks, CummulativePacks.PackQuantity, CummulativePacks.PackLineVolume, Batches.CreatedDate, Batches.EditedDate, Batches.IsDefault, Batches.InActive " + "\r\n";
            queryString = queryString + "       FROM        Batches " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON Batches.FillingLineID = @FillingLineID AND (@ActiveOption = -1 OR Batches.InActive = @ActiveOption) AND ((Batches.EntryDate >= @FromDate AND Batches.EntryDate <= @ToDate) OR Batches.IsDefault = 1) AND Batches.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BatchTypes ON Batches.BatchTypeID = BatchTypes.BatchTypeID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN (SELECT BatchID, SUM(1) AS PackQuantity, SUM(LineVolume) AS PackLineVolume FROM Packs GROUP BY BatchID) CummulativePacks ON Batches.BatchID = CummulativePacks.BatchID " + "\r\n";
            

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchIndexes", queryString);
        }

        private void GetPendingLots()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          Lots.LotID, Lots.Code AS LotCode, BatchMasters.BatchMasterID, BatchMasters.EntryDate, BatchMasters.Code, BatchMasters.PlannedQuantity, BatchStatuses.Code AS BatchStatusCode, BatchStatuses.Remarks, BatchMasters.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.APICode AS CommodityAPICode, Commodities.CartonCode AS CommodityCartonCode, Commodities.Volume, Commodities.PackPerCarton, Commodities.CartonPerPallet " + "\r\n";
            queryString = queryString + "       FROM            Lots " + "\r\n";
            queryString = queryString + "                       INNER JOIN BatchMasters ON Lots.LocationID = @LocationID AND Lots.BatchMasterID = BatchMasters.BatchMasterID " + "\r\n";
            queryString = queryString + "                       INNER JOIN Commodities ON BatchMasters.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                       INNER JOIN BatchStatuses ON BatchMasters.BatchStatusID = BatchStatuses.BatchStatusID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingLots", queryString);
        }

        private void BatchEditable()
        {
            string[] queryArray = new string[4];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = BatchID FROM Batches WHERE BatchID = @EntityID AND InActive = 1 "; //Don't allow edit after void
            queryArray[1] = " SELECT TOP 1 @FoundEntity = BatchID FROM Pallets WHERE BatchID = @EntityID ";
            queryArray[2] = " SELECT TOP 1 @FoundEntity = BatchID FROM Cartons WHERE BatchID = @EntityID ";
            queryArray[3] = " SELECT TOP 1 @FoundEntity = BatchID FROM Packs WHERE BatchID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("BatchEditable", queryArray);
        }

        private void BatchPostSaveValidate()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày xuất kho: ' + CAST(GoodsIssueDetails.EntryDate AS nvarchar) FROM BatchDetails INNER JOIN GoodsIssueDetails ON BatchDetails.BatchID = @EntityID AND BatchDetails.GoodsIssueDetailID = GoodsIssueDetails.GoodsIssueDetailID AND BatchDetails.EntryDate < GoodsIssueDetails.EntryDate ";
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Ngày xuất kho: ' + CAST(CAST(GoodsIssueDetails.EntryDate AS Date) AS nvarchar) + N' (Ngày HĐ phải sau ngày xuất kho)' FROM BatchDetails INNER JOIN GoodsIssueDetails ON BatchDetails.BatchID = @EntityID AND BatchDetails.GoodsIssueDetailID = GoodsIssueDetails.GoodsIssueDetailID AND BatchDetails.VATInvoiceDate < CAST(GoodsIssueDetails.EntryDate AS Date) ";
            //queryArray[2] = " SELECT TOP 1 @FoundEntity = N'Số lượng xuất hóa đơn vượt quá số lượng xuất kho: ' + CAST(ROUND(GoodsIssueDetails.Quantity - GoodsIssueDetails.QuantityInvoice, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) + ' OR free quantity: ' + CAST(ROUND(GoodsIssueDetails.FreeQuantity - GoodsIssueDetails.FreeQuantityInvoice, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) FROM BatchDetails INNER JOIN GoodsIssueDetails ON BatchDetails.BatchID = @EntityID AND BatchDetails.GoodsIssueDetailID = GoodsIssueDetails.GoodsIssueDetailID AND (ROUND(GoodsIssueDetails.Quantity - GoodsIssueDetails.QuantityInvoice, " + (int)GlobalEnums.rndQuantity + ") < 0 OR ROUND(GoodsIssueDetails.FreeQuantity - GoodsIssueDetails.FreeQuantityInvoice, " + (int)GlobalEnums.rndQuantity + ") < 0) ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("BatchPostSaveValidate", queryArray);
        }

        private void BatchToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       DECLARE @FillingLineID int ";
            queryString = queryString + "       SELECT @FillingLineID = FillingLineID FROM Batches WHERE BatchID = @EntityID ";

            queryString = queryString + "       UPDATE      Batches  SET IsDefault = ~@Approved WHERE FillingLineID = @FillingLineID AND BatchID <> @EntityID AND IsDefault =  @Approved" + "\r\n";
            queryString = queryString + "       UPDATE      Batches  SET IsDefault =  @Approved WHERE FillingLineID = @FillingLineID AND BatchID =  @EntityID AND IsDefault = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT <> 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Không thể cài đặt batch này cho sản xuất' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("BatchToggleApproved", queryString);
        }

        private void BatchToggleVoid()
        {
            string queryString = " @EntityID int, @InActive bit, @VoidTypeID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      FillingLines SET PalletChanged = 1 WHERE FillingLineID = (SELECT FillingLineID FROM Batches WHERE BatchID = @EntityID) " + "\r\n";
            queryString = queryString + "       UPDATE      Batches  SET InActive = @InActive, InActiveDate = GetDate() WHERE BatchID = @EntityID AND InActive = ~@InActive" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT <> 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Batch không tồn tại hoặc ' + iif(@InActive = 0, 'đang', 'dừng')  + ' sản xuất' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";


            this.totalSmartCodingEntities.CreateStoredProcedure("BatchToggleVoid", queryString);
        }

        private void BatchInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("Batches", "BatchID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.Batch));
            this.totalSmartCodingEntities.CreateTrigger("BatchInitReference", simpleInitReference.CreateQuery());
        }


        private void BatchAddLot()
        {
            string queryString = " @BatchID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       DECLARE     @LotCode nvarchar(10), @NextPackNo nvarchar(10), @NextCartonNo nvarchar(10), @NextPalletNo nvarchar(10) ";
            queryString = queryString + "       SELECT      @LotCode = LotCode, @NextPackNo = NextPackNo, @NextCartonNo = NextCartonNo, @NextPalletNo = NextPalletNo FROM Batches WHERE BatchID = (SELECT MAX(BatchID) FROM Batches WHERE Code = (SELECT Code FROM Batches WHERE BatchID = @BatchID)) ";

            queryString = queryString + "       SELECT      @LotCode = CHAR(CASE WHEN (ASCII(@LotCode) >= 49 AND ASCII(@LotCode) < 57) OR (ASCII(@LotCode) >= 65 AND ASCII(@LotCode) < 90) THEN ASCII(@LotCode) + 1 WHEN ASCII(@LotCode) = 57 THEN 65 ELSE 97 END), @NextPackNo = RIGHT(CAST(CAST(@NextPackNo AS int) + 1000001 AS varchar), 5), @NextCartonNo = RIGHT(CAST(CAST(@NextCartonNo AS int) + 1000001 AS varchar), 5), @NextPalletNo = RIGHT(CAST(CAST(@NextPalletNo AS int) + 1000001 AS varchar), 5) " + "\r\n";

            queryString = queryString + "       INSERT INTO Batches (EntryDate, Reference, Code, LotCode, FillingLineID, CommodityID, LocationID, NextPackNo, NextCartonNo, NextPalletNo, Description, Remarks, CreatedDate, EditedDate, IsDefault, InActive, InActiveDate) " + "\r\n";
            queryString = queryString + "       SELECT      EntryDate, Code + @LotCode AS Reference, Code, @LotCode, FillingLineID, CommodityID, LocationID, @NextPackNo, @NextCartonNo, @NextPalletNo, Description, Remarks, GETDATE() AS CreatedDate, GETDATE() AS EditedDate, 0 AS IsDefault, 0 AS InActive, NULL AS InActiveDate " + "\r\n";
            queryString = queryString + "       FROM        Batches " + "\r\n";
            queryString = queryString + "       WHERE       BatchID = @BatchID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("BatchAddLot", queryString);
        }

        private void BatchCommonUpdate()
        {
            string queryString = " @BatchID int, @NextPackNo nvarchar(10), @NextCartonNo nvarchar(10), @NextPalletNo nvarchar(10) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       UPDATE      Batches" + "\r\n";
            queryString = queryString + "       SET         NextPackNo = CASE WHEN @NextPackNo != '' THEN @NextPackNo ELSE NextPackNo END, NextCartonNo = CASE WHEN @NextCartonNo != '' THEN @NextCartonNo ELSE NextCartonNo END, NextPalletNo = CASE WHEN @NextPalletNo != '' THEN @NextPalletNo ELSE NextPalletNo END " + "\r\n";
            queryString = queryString + "       WHERE       BatchID = @BatchID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("BatchCommonUpdate", queryString);
        }


    }
}
