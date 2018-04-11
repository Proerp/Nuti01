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
            this.GetBatchRepacks();

            this.BatchEditable();
            this.BatchPostSaveValidate();

            this.BatchToggleApproved();
            this.BatchToggleVoid();

            this.BatchInitReference(); //NOT USE THIS ANY MORE. NOW: Reference = Code + LotCode

            this.BatchAddLot();

            this.BatchCommonUpdate();
            this.BatchRepackUpdate();
        }


        private void GetBatchIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @FillingLineID int, @ShowCummulativePacks bit, @ActiveOption int, @DefaultOnly bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF  (@ActiveOption <> -1) " + "\r\n";
            queryString = queryString + "           " + this.GetBatchIndexSQL(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.GetBatchIndexSQL(false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchIndexes", queryString);
        }

        private string GetBatchIndexSQL(bool isActiveOption)
        {
            string queryString = "";

            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@DefaultOnly = 1) " + "\r\n";
            queryString = queryString + "           " + this.GetBatchIndexSQL(isActiveOption, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.GetBatchIndexSQL(isActiveOption, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string GetBatchIndexSQL(bool isActiveOption, bool defaultOnly)
        {
            string queryString = "";

            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@ShowCummulativePacks = 1) " + "\r\n";
            queryString = queryString + "           " + this.GetBatchIndexSQL(isActiveOption, defaultOnly, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.GetBatchIndexSQL(isActiveOption, defaultOnly, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string GetBatchIndexSQL(bool isActiveOption, bool defaultOnly, bool showCummulativePacks)
        {
            string queryString = "";

            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       SELECT      Batches.BatchID, CAST(Batches.EntryDate AS DATE) AS EntryDate, Batches.Reference, Batches.Code AS BatchCode, Batches.LotCode, Batches.FillingLineID, Batches.CommodityID, Commodities.Code AS CommodityCode, Commodities.OfficialCode AS CommodityOfficialCode, Commodities.Name AS CommodityName, Commodities.APICode AS CommodityAPICode, Commodities.CartonCode AS CommodityCartonCode, Commodities.Volume, Commodities.PackPerCarton, Commodities.CartonPerPallet, Commodities.Shelflife, " + "\r\n";
            queryString = queryString + "                   Batches.BatchTypeID, BatchTypes.Code AS BatchTypeCode, BatchTypes.Code + '-' + BatchTypes.Name AS BatchTypeCodeName, Batches.NextPackNo, Batches.NextCartonNo, Batches.NextPalletNo, Batches.Description, Batches.Remarks, " + (showCummulativePacks ? "CummulativePacks.PackQuantity" : "CAST(0 AS int) AS PackQuantity") + ", " + (showCummulativePacks ? "CummulativePacks.PackLineVolume" : "CAST(0 AS decimal(18, 2)) AS PackLineVolume") + ", Batches.CreatedDate, Batches.EditedDate, Batches.IsDefault, Batches.InActive " + "\r\n";
            queryString = queryString + "       FROM        Batches " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON Batches.FillingLineID = @FillingLineID " + (isActiveOption ? "AND Batches.InActive = @ActiveOption" : "") + " AND " + (defaultOnly ? "Batches.IsDefault = 1" : "((Batches.EntryDate >= @FromDate AND Batches.EntryDate <= @ToDate) OR Batches.IsDefault = 1) ") + " AND Batches.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BatchMasters ON BatchMasters.InActive = 0 AND Batches.BatchMasterID = BatchMasters.BatchMasterID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BatchTypes ON Batches.BatchTypeID = BatchTypes.BatchTypeID " + "\r\n";

            if (showCummulativePacks)
                queryString = queryString + "               LEFT JOIN (SELECT BatchID, SUM(1) AS PackQuantity, SUM(LineVolume) AS PackLineVolume FROM Packs GROUP BY BatchID) CummulativePacks ON Batches.BatchID = CummulativePacks.BatchID " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private void GetPendingLots()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          Lots.LotID, Lots.Code AS LotCode, BatchMasters.BatchMasterID, BatchMasters.EntryDate, BatchMasters.Code, BatchMasters.PlannedQuantity, BatchStatuses.Code AS BatchStatusCode, BatchStatuses.Remarks, BatchMasters.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.APICode AS CommodityAPICode, Commodities.CartonCode AS CommodityCartonCode, Commodities.Volume, Commodities.PackPerCarton, Commodities.CartonPerPallet, LastBatches.NextPackNo, LastBatches.NextCartonNo, LastBatches.NextPalletNo " + "\r\n";
            queryString = queryString + "       FROM            Lots " + "\r\n";
            queryString = queryString + "                       INNER JOIN BatchMasters ON Lots.LocationID = @LocationID AND BatchMasters.InActive = 0 AND Lots.BatchMasterID = BatchMasters.BatchMasterID " + "\r\n";
            queryString = queryString + "                       INNER JOIN Commodities ON BatchMasters.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                       INNER JOIN BatchStatuses ON BatchMasters.BatchStatusID = BatchStatuses.BatchStatusID " + "\r\n";

            queryString = queryString + "                       LEFT JOIN (SELECT Batches.LotID, MAX(Batches.NextPackNo) AS NextPackNo, MAX(Batches.NextCartonNo) AS NextCartonNo, MAX(Batches.NextPalletNo) AS NextPalletNo FROM Batches INNER JOIN BatchMasters ON Batches.BatchMasterID = BatchMasters.BatchMasterID WHERE BatchMasters.InActive = 0 GROUP BY Batches.LotID) LastBatches ON Lots.LotID = LastBatches.LotID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingLots", queryString);
        }

        private void GetBatchRepacks()
        {
            string queryString = " @BatchID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          Repacks.RepackID, Repacks.PackID, Batches.BatchID, Batches.EntryDate, Batches.Code AS BatchCode, Batches.LotCode, Packs.Code, Packs.FillingLineID, FillingLines.Code AS FillingLineCode, Repacks.PrintedTimes " + "\r\n";
            queryString = queryString + "       FROM            Repacks " + "\r\n"; //Packs.BatchID: SAVED BATCH; Repacks.BatchID: REPACK BATCH
            queryString = queryString + "                       INNER JOIN Packs ON Repacks.PrintedTimes = 0 AND Repacks.BatchID = @BatchID AND Repacks.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                       INNER JOIN FillingLines ON Packs.FillingLineID = FillingLines.FillingLineID " + "\r\n"; 
            queryString = queryString + "                       INNER JOIN Batches ON Packs.BatchID = Batches.BatchID " + "\r\n";
            queryString = queryString + "                       INNER JOIN Commodities ON Packs.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "       ORDER BY        Repacks.RepackID " + "\r\n"; //!!!!VERY IMPORTANT: BECAUSE: WE TREAT THIS ORDER WHEN PRINTING. SEE BatchRepackUpdate!!!!

            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchRepacks", queryString);
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

        private void BatchRepackUpdate()
        {
            string queryString = " @BatchID int, @RepackID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       UPDATE      Repacks" + "\r\n";
            queryString = queryString + "       SET         PrintedTimes = 1 " + "\r\n";
            queryString = queryString + "       WHERE       BatchID = @BatchID AND RepackID <= @RepackID AND PrintedTimes = 0 " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("BatchRepackUpdate", queryString);
        }
        
    }
}
