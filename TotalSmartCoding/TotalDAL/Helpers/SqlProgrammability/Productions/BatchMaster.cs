﻿using System;
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

            this.BatchMasterEditable();
            this.BatchMasterPostSaveValidate();

            this.BatchMasterToggleVoid();

            this.BatchMasterInitReference(); //NOT USE THIS ANY MORE. NOW: Reference = Code + LotNumber

            //this.BatchMasterAddLot();
        }


        private void GetBatchMasterIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @ActiveOption int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      BatchMasters.BatchMasterID, CAST(BatchMasters.EntryDate AS DATE) AS EntryDate, BatchMasters.Reference, BatchMasters.Code AS BatchMasterCode, BatchMasters.BatchStatusID, BatchStatuses.Code AS BatchStatusCode, BatchMasters.CommodityID, Commodities.Code AS CommodityCode, Commodities.OfficialCode AS CommodityOfficialCode, Commodities.Name AS CommodityName, Commodities.APICode AS CommodityAPICode, Commodities.CartonCode AS CommodityCartonCode, Commodities.Volume, Commodities.PackPerCarton, Commodities.CartonPerPallet, Commodities.Shelflife, " + "\r\n";
            queryString = queryString + "                   BatchMasters.PlannedQuantity, BatchMasters.Description, BatchMasters.Remarks, CummulativePacks.PackQuantity, CummulativePacks.PackLineVolume, BatchMasters.CreatedDate, BatchMasters.EditedDate, BatchMasters.IsDefault, BatchMasters.InActive " + "\r\n";
            queryString = queryString + "       FROM        BatchMasters " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON (@ActiveOption = -1 OR BatchMasters.InActive = @ActiveOption) AND BatchMasters.EntryDate >= @FromDate AND BatchMasters.EntryDate <= @ToDate AND BatchMasters.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BatchStatuses ON BatchMasters.BatchStatusID = BatchStatuses.BatchStatusID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN (SELECT Batches.BatchMasterID, SUM(1) AS PackQuantity, SUM(Packs.LineVolume) AS PackLineVolume FROM Packs INNER JOIN Batches ON Packs.BatchID = Batches.BatchID GROUP BY Batches.BatchMasterID) CummulativePacks ON BatchMasters.BatchMasterID = CummulativePacks.BatchMasterID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchMasterIndexes", queryString);
        }



        private void BatchMasterEditable()
        {
            string[] queryArray = new string[2];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = BatchMasterID FROM BatchMasters WHERE BatchMasterID = @EntityID AND InActive = 1 "; //Don't allow edit after void
            queryArray[1] = " SELECT TOP 1 @FoundEntity = BatchMasterID FROM Batches WHERE BatchMasterID = @EntityID ";

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

            queryString = queryString + "       DECLARE     @LotNumber nvarchar(10), @NextPackNo nvarchar(10), @NextCartonNo nvarchar(10), @NextPalletNo nvarchar(10) ";
            queryString = queryString + "       SELECT      @LotNumber = LotNumber, @NextPackNo = NextPackNo, @NextCartonNo = NextCartonNo, @NextPalletNo = NextPalletNo FROM BatchMasters WHERE BatchMasterID = (SELECT MAX(BatchMasterID) FROM BatchMasters WHERE Code = (SELECT Code FROM BatchMasters WHERE BatchMasterID = @BatchMasterID)) ";

            queryString = queryString + "       SELECT      @LotNumber = CHAR(CASE WHEN (ASCII(@LotNumber) >= 49 AND ASCII(@LotNumber) < 57) OR (ASCII(@LotNumber) >= 65 AND ASCII(@LotNumber) < 90) THEN ASCII(@LotNumber) + 1 WHEN ASCII(@LotNumber) = 57 THEN 65 ELSE 97 END), @NextPackNo = RIGHT(CAST(CAST(@NextPackNo AS int) + 1000001 AS varchar), 5), @NextCartonNo = RIGHT(CAST(CAST(@NextCartonNo AS int) + 1000001 AS varchar), 5), @NextPalletNo = RIGHT(CAST(CAST(@NextPalletNo AS int) + 1000001 AS varchar), 5) " + "\r\n";

            queryString = queryString + "       INSERT INTO BatchMasters (EntryDate, Reference, Code, LotNumber, FillingLineID, CommodityID, LocationID, NextPackNo, NextCartonNo, NextPalletNo, Description, Remarks, CreatedDate, EditedDate, IsDefault, InActive, InActiveDate) " + "\r\n";
            queryString = queryString + "       SELECT      EntryDate, Code + @LotNumber AS Reference, Code, @LotNumber, FillingLineID, CommodityID, LocationID, @NextPackNo, @NextCartonNo, @NextPalletNo, Description, Remarks, GETDATE() AS CreatedDate, GETDATE() AS EditedDate, 0 AS IsDefault, 0 AS InActive, NULL AS InActiveDate " + "\r\n";
            queryString = queryString + "       FROM        BatchMasters " + "\r\n";
            queryString = queryString + "       WHERE       BatchMasterID = @BatchMasterID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("BatchMasterAddLot", queryString);
        }


    }
}