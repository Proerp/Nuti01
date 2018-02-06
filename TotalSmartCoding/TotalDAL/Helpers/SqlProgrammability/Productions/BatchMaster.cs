using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Productions
{
    public class BatchMaster
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public BatchMaster(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetBatchMasterIndexes();

            this.BatchMasterApproved();
            this.BatchMasterEditable();
            this.BatchMasterPostSaveValidate();

            this.BatchMasterToggleApproved();
            this.BatchMasterToggleVoid();

            this.BatchMasterInitReference();
            this.BatchMasterAddLot();
            this.BatchMasterRemoveLot();

            this.GetBatchMasterBases();
        }


        private void GetBatchMasterIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @ActiveOption int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      BatchMasters.BatchMasterID, CAST(BatchMasters.EntryDate AS DATE) AS EntryDate, BatchMasters.Reference, BatchMasters.Code AS BatchMasterCode, BatchMasters.BatchStatusID, BatchStatuses.Code AS BatchStatusCode, BatchMasters.CommodityID, Commodities.Code AS CommodityCode, Commodities.OfficialCode AS CommodityOfficialCode, Commodities.Name AS CommodityName, Commodities.APICode AS CommodityAPICode, Commodities.CartonCode AS CommodityCartonCode, Commodities.Volume, Commodities.PackPerCarton, Commodities.CartonPerPallet, Commodities.Shelflife, " + "\r\n";
            queryString = queryString + "                   Lots.LotID, Lots.EntryDate AS LotEntryDate, Lots.Code AS LotCode, BatchMasters.Description, BatchMasters.Remarks, BatchMasters.PlannedQuantity, CummulativePacks.PackQuantity, CummulativePacks.PackLineVolume, BatchMasters.CreatedDate, BatchMasters.EditedDate, BatchMasters.IsDefault, BatchMasters.InActive " + "\r\n";
            queryString = queryString + "       FROM        BatchMasters " + "\r\n"; //AND BatchMasters.EntryDate >= @FromDate AND BatchMasters.EntryDate <= @ToDate 
            queryString = queryString + "                   INNER JOIN Commodities ON (@ActiveOption = -1 OR BatchMasters.InActive = @ActiveOption) AND BatchMasters.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BatchStatuses ON BatchMasters.BatchStatusID = BatchStatuses.BatchStatusID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN Lots ON BatchMasters.BatchMasterID = Lots.BatchMasterID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT Batches.BatchMasterID, SUM(1) AS PackQuantity, SUM(Packs.LineVolume) AS PackLineVolume FROM Packs INNER JOIN Batches ON Packs.BatchID = Batches.BatchID GROUP BY Batches.BatchMasterID) CummulativePacks ON BatchMasters.BatchMasterID = CummulativePacks.BatchMasterID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchMasterIndexes", queryString);
        }

        private void BatchMasterApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = BatchMasterID FROM BatchMasters WHERE BatchMasterID = @EntityID AND Approved = 1";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("BatchMasterApproved", queryArray);
        }

        private void BatchMasterEditable()
        {
            string[] queryArray = new string[3];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = BatchMasterID FROM BatchMasters WHERE BatchMasterID = @EntityID AND InActive = 1 "; //Don't allow edit after void
            queryArray[1] = " SELECT TOP 1 @FoundEntity = BatchMasterID FROM Lots WHERE BatchMasterID = @EntityID ";
            queryArray[2] = " SELECT TOP 1 @FoundEntity = BatchMasterID FROM Batches WHERE BatchMasterID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("BatchMasterEditable", queryArray);
        }

        private void BatchMasterPostSaveValidate()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày xuất kho: ' + CAST(GoodsIssueDetails.EntryDate AS nvarchar) FROM BatchMasterDetails INNER JOIN GoodsIssueDetails ON BatchMasterDetails.BatchMasterID = @EntityID AND BatchMasterDetails.GoodsIssueDetailID = GoodsIssueDetails.GoodsIssueDetailID AND BatchMasterDetails.EntryDate < GoodsIssueDetails.EntryDate ";
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Ngày xuất kho: ' + CAST(CAST(GoodsIssueDetails.EntryDate AS Date) AS nvarchar) + N' (Ngày HĐ phải sau ngày xuất kho)' FROM BatchMasterDetails INNER JOIN GoodsIssueDetails ON BatchMasterDetails.BatchMasterID = @EntityID AND BatchMasterDetails.GoodsIssueDetailID = GoodsIssueDetails.GoodsIssueDetailID AND BatchMasterDetails.VATInvoiceDate < CAST(GoodsIssueDetails.EntryDate AS Date) ";
            //queryArray[2] = " SELECT TOP 1 @FoundEntity = N'Số lượng xuất hóa đơn vượt quá số lượng xuất kho: ' + CAST(ROUND(GoodsIssueDetails.Quantity - GoodsIssueDetails.QuantityInvoice, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) + ' OR free quantity: ' + CAST(ROUND(GoodsIssueDetails.FreeQuantity - GoodsIssueDetails.FreeQuantityInvoice, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) FROM BatchMasterDetails INNER JOIN GoodsIssueDetails ON BatchMasterDetails.BatchMasterID = @EntityID AND BatchMasterDetails.GoodsIssueDetailID = GoodsIssueDetails.GoodsIssueDetailID AND (ROUND(GoodsIssueDetails.Quantity - GoodsIssueDetails.QuantityInvoice, " + (int)GlobalEnums.rndQuantity + ") < 0 OR ROUND(GoodsIssueDetails.FreeQuantity - GoodsIssueDetails.FreeQuantityInvoice, " + (int)GlobalEnums.rndQuantity + ") < 0) ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("BatchMasterPostSaveValidate", queryArray);
        }

        private void BatchMasterToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      BatchMasters  SET Approved = @Approved, ApprovedDate = GetDate() WHERE BatchMasterID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT <> 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, 'hủy', '')  + ' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("BatchMasterToggleApproved", queryString);
        }

        private void BatchMasterToggleVoid()
        {
            string queryString = " @EntityID int, @InActive bit, @VoidTypeID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      BatchMasters  SET InActive = @InActive, InActiveDate = GetDate() WHERE BatchMasterID = @EntityID AND InActive = ~@InActive" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT <> 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Batch không tồn tại hoặc ' + iif(@InActive = 0, 'đang', 'dừng')  + ' sản xuất' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";


            this.totalSmartCodingEntities.CreateStoredProcedure("BatchMasterToggleVoid", queryString);
        }

        private void BatchMasterInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("BatchMasters", "BatchMasterID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.BatchMaster));
            this.totalSmartCodingEntities.CreateTrigger("BatchMasterInitReference", simpleInitReference.CreateQuery());
        }

        private void BatchMasterAddLot()
        {
            string queryString = " @BatchMasterID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       DECLARE     @EntryDate DateTime, @Code nvarchar(10) ";
            queryString = queryString + "       SET         @EntryDate = GetDate() ";
            queryString = queryString + "       SELECT      @Code = MAX(Code) FROM Lots WHERE BatchMasterID = @BatchMasterID ";

            queryString = queryString + "       SELECT      @Code = CHAR(CASE WHEN @Code IS NULL THEN 48 WHEN (ASCII(@Code) >= 48 AND ASCII(@Code) < 57) OR (ASCII(@Code) >= 65 AND ASCII(@Code) < 90) THEN ASCII(@Code) + 1 WHEN ASCII(@Code) = 57 THEN 65 ELSE 97 END) " + "\r\n";

            queryString = queryString + "       INSERT INTO Lots (EntryDate, Reference, Code, BatchMasterID, LocationID, Description, Remarks, CreatedDate, EditedDate, Approved, ApprovedDate, InActive, InActiveDate) " + "\r\n";
            queryString = queryString + "       SELECT      @EntryDate AS EntryDate, @Code AS Reference, @Code, BatchMasterID, LocationID, NULL AS Description, NULL AS Remarks, @EntryDate AS CreatedDate, @EntryDate AS EditedDate, 0 AS Approved, NULL AS ApprovedDate, 0 AS InActive, NULL AS InActiveDate " + "\r\n";
            queryString = queryString + "       FROM        BatchMasters " + "\r\n";
            queryString = queryString + "       WHERE       BatchMasterID = @BatchMasterID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("BatchMasterAddLot", queryString);
        }

        private void BatchMasterRemoveLot()
        {
            string queryString = " @LotID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       DECLARE @FoundBatchID int " + "\r\n";
            queryString = queryString + "       SELECT TOP 1 @FoundBatchID = BatchID FROM Batches WHERE LotID = @LotID " + "\r\n";

            queryString = queryString + "       IF NOT @FoundBatchID IS NULL " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Lot này đã sản xuất rồi, vui lòng kiểm tra lại' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "               DELETE FROM Lots WHERE LotID = @LotID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("BatchMasterRemoveLot", queryString);
        }

        private void GetBatchMasterBases()
        {
            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchMasterBases", this.GetBatchMasterBUILD(0));
            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchMasterBase", this.GetBatchMasterBUILD(1));
            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchMasterBaseByCode", this.GetBatchMasterBUILD(2));
        }

        private string GetBatchMasterBUILD(int switchID)
        {
            string queryString;

            queryString = (switchID == 0 ? "" : (switchID == 1 ? "@BatchMasterID int" : "@Code nvarchar(50)")) + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      BatchMasters.BatchMasterID, BatchMasters.EntryDate, BatchMasters.Code, ISNULL(BatchMasters.PlannedQuantity, 0) AS PlannedQuantity, ISNULL(CummulativePacks.PackQuantity, 0) AS PackQuantity, ISNULL(CummulativePacks.PackLineVolume, 0) AS PackLineVolume, BatchStatuses.Code AS BatchStatusCode, BatchMasters.Remarks, " + "\r\n";
            queryString = queryString + "                   BatchMasters.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.APICode AS CommodityAPICode, Commodities.CartonCode AS CommodityCartonCode, Commodities.Volume, Commodities.Shelflife, Commodities.PackPerCarton, Commodities.CartonPerPallet " + "\r\n";
            queryString = queryString + "       FROM        BatchMasters " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON BatchMasters." + (switchID == 0 ? "Approved = 1" : (switchID == 1 ? "BatchMasterID = @BatchMasterID" : "Code = @Code")) + " AND BatchMasters.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BatchStatuses ON BatchMasters.BatchStatusID = BatchStatuses.BatchStatusID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT Batches.BatchMasterID, SUM(1) AS PackQuantity, SUM(Packs.LineVolume) AS PackLineVolume FROM Packs INNER JOIN Batches ON Packs.BatchID = Batches.BatchID GROUP BY Batches.BatchMasterID) CummulativePacks ON BatchMasters.BatchMasterID = CummulativePacks.BatchMasterID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }
    }
}
