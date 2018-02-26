﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;

using TotalBase;
using TotalBase.Enums;
using TotalDAL.Helpers;
using TotalModel.Models;
using TotalCore.Repositories;


namespace TotalDAL.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public BaseRepository(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.RepositoryBag = new Dictionary<string, object>();
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        private ObjectContext TotalBikePortalsObjectContext
        {
            get { return ((IObjectContextAdapter)this.totalSmartCodingEntities).ObjectContext; }
        }

        public TotalSmartCodingEntities TotalSmartCodingEntities { get { return this.totalSmartCodingEntities; } }


        public bool AutoUpdates(bool restoreProcedures)
        {
            this.UpdateDatabases(restoreProcedures);

            if (restoreProcedures || this.GetStoredID(GlobalVariables.ConfigID) < GlobalVariables.MaxConfigVersionID()) this.RestoreProcedures();

            return this.GetStoredID(GlobalVariables.ConfigID) == GlobalVariables.MaxConfigVersionID();
        }

        public void UpdateDatabases(bool restoreProcedures)
        {
            if (restoreProcedures)
            {
                this.totalSmartCodingEntities.ColumnAdd("Configs", "StoredID", "int", "0", true);
            }


        }

        public bool RestoreProcedures()
        {
            this.CreateStoredProcedure();

            //SET LASTEST VERSION AFTER RESTORE SUCCESSFULL
            this.ExecuteStoreCommand("UPDATE Configs SET StoredID = " + GlobalVariables.MaxConfigVersionID() + " WHERE StoredID < " + GlobalVariables.MaxConfigVersionID(), new ObjectParameter[] { });

            //this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.BatchMaster + ", 108, 'Reports', 'Reports', '#', '#', '#', 1, 10, 1, 0) ", new ObjectParameter[] { });
            //this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.BatchMaster + " AS NMVNTaskID, OrganizationalUnitID, 2 AS AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodity + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.BatchMaster + ") = 0", new ObjectParameter[] { }); 

            ////this.ExecuteStoreCommand(" DELETE FROM  Packs   WHERE (EntryDate < CONVERT(DATETIME, '2018-07-02 00:00:00', 102)) ", new ObjectParameter[] { });
            ////this.ExecuteStoreCommand(" DELETE FROM  Cartons WHERE (EntryDate < CONVERT(DATETIME, '2018-07-02 00:00:00', 102)) ", new ObjectParameter[] { });
            ////this.ExecuteStoreCommand(" DELETE FROM  Pallets WHERE (EntryDate < CONVERT(DATETIME, '2018-07-02 00:00:00', 102)) ", new ObjectParameter[] { });

            return true;
        }


        public void CreateStoredProcedure()
        {

            //return;

            Helpers.SqlProgrammability.Generals.OleDb oleDb = new Helpers.SqlProgrammability.Generals.OleDb(totalSmartCodingEntities);
            oleDb.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Productions.BatchMaster batchMaster = new Helpers.SqlProgrammability.Productions.BatchMaster(totalSmartCodingEntities);
            batchMaster.RestoreProcedure();

            ////return;

            Helpers.SqlProgrammability.Productions.Batch batch = new Helpers.SqlProgrammability.Productions.Batch(totalSmartCodingEntities);
            batch.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Commodity commodity = new Helpers.SqlProgrammability.Commons.Commodity(totalSmartCodingEntities);
            commodity.RestoreProcedure();


            ////return;

            Helpers.SqlProgrammability.Commons.CommodityCategory commodityCategory = new Helpers.SqlProgrammability.Commons.CommodityCategory(totalSmartCodingEntities);
            commodityCategory.RestoreProcedure();

            ////return;

            Helpers.SqlProgrammability.Commons.BinLocation binLocation = new Helpers.SqlProgrammability.Commons.BinLocation(totalSmartCodingEntities);
            binLocation.RestoreProcedure();

            ////return;

            Helpers.SqlProgrammability.Commons.Location location = new Helpers.SqlProgrammability.Commons.Location(totalSmartCodingEntities);
            location.RestoreProcedure();


            ////return;

            Helpers.SqlProgrammability.Commons.FillingLine fillingLine = new Helpers.SqlProgrammability.Commons.FillingLine(totalSmartCodingEntities);
            fillingLine.RestoreProcedure();



            //return;

            Helpers.SqlProgrammability.Commons.BatchType batchType = new Helpers.SqlProgrammability.Commons.BatchType(totalSmartCodingEntities);
            batchType.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.BatchStatus batchStatus = new Helpers.SqlProgrammability.Commons.BatchStatus(totalSmartCodingEntities);
            batchStatus.RestoreProcedure();

            return;

            Helpers.SqlProgrammability.Productions.Pack pack = new Helpers.SqlProgrammability.Productions.Pack(totalSmartCodingEntities);
            pack.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Productions.Carton carton = new Helpers.SqlProgrammability.Productions.Carton(totalSmartCodingEntities);
            carton.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Productions.Pallet pallet = new Helpers.SqlProgrammability.Productions.Pallet(totalSmartCodingEntities);
            pallet.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Employee employee = new Helpers.SqlProgrammability.Commons.Employee(totalSmartCodingEntities);
            employee.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.Inventory inventory = new Helpers.SqlProgrammability.Inventories.Inventory(totalSmartCodingEntities);
            inventory.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.GoodsReceipt goodsReceipt = new Helpers.SqlProgrammability.Inventories.GoodsReceipt(totalSmartCodingEntities);
            goodsReceipt.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Inventories.GoodsIssue goodsIssue = new Helpers.SqlProgrammability.Inventories.GoodsIssue(totalSmartCodingEntities);
            goodsIssue.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.Pickup pickup = new Helpers.SqlProgrammability.Inventories.Pickup(totalSmartCodingEntities);
            pickup.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Sales.SalesOrder salesOrder = new Helpers.SqlProgrammability.Sales.SalesOrder(totalSmartCodingEntities);
            salesOrder.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Sales.DeliveryAdvice deliveryAdvice = new Helpers.SqlProgrammability.Sales.DeliveryAdvice(totalSmartCodingEntities);
            deliveryAdvice.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Sales.TransferOrder transferOrder = new Helpers.SqlProgrammability.Sales.TransferOrder(totalSmartCodingEntities);
            transferOrder.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.WarehouseAdjustment warehouseAdjustment = new Helpers.SqlProgrammability.Inventories.WarehouseAdjustment(totalSmartCodingEntities);
            warehouseAdjustment.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Commons.TransferOrderType transferOrderType = new Helpers.SqlProgrammability.Commons.TransferOrderType(totalSmartCodingEntities);
            transferOrderType.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Commons.Warehouse warehouse = new Helpers.SqlProgrammability.Commons.Warehouse(totalSmartCodingEntities);
            warehouse.RestoreProcedure();





            //return;

            Helpers.SqlProgrammability.Commons.Customer customer = new Helpers.SqlProgrammability.Commons.Customer(totalSmartCodingEntities);
            customer.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Generals.Module module = new Helpers.SqlProgrammability.Generals.Module(totalSmartCodingEntities);
            module.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Commons.CustomerCategory customerCategory = new Helpers.SqlProgrammability.Commons.CustomerCategory(totalSmartCodingEntities);
            customerCategory.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.CustomerType customerType = new Helpers.SqlProgrammability.Commons.CustomerType(totalSmartCodingEntities);
            customerType.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Territory territory = new Helpers.SqlProgrammability.Commons.Territory(totalSmartCodingEntities);
            territory.RestoreProcedure();




            //return;

            Helpers.SqlProgrammability.Commons.WarehouseAdjustmentType warehouseAdjustmentType = new Helpers.SqlProgrammability.Commons.WarehouseAdjustmentType(totalSmartCodingEntities);
            warehouseAdjustmentType.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Generals.UserReference userReference = new Helpers.SqlProgrammability.Generals.UserReference(totalSmartCodingEntities);
            userReference.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Commons.AccessControl accessControl = new Helpers.SqlProgrammability.Commons.AccessControl(totalSmartCodingEntities);
            accessControl.RestoreProcedure();





        }


        #region Backup for update log
        private void UpdateBackup()
        {


            //if (!this.totalSmartCodingEntities.ColumnExists("GoodsReceipts", "ForkliftDriverID"))
            //{
            //    this.totalSmartCodingEntities.ColumnAdd("GoodsReceipts", "ForkliftDriverID", "int", "1", true);
            //    this.totalSmartCodingEntities.ColumnAdd("GoodsReceipts", "VehicleDriver", "nvarchar(100)", "", false);

            //    this.ExecuteStoreCommand("UPDATE GoodsReceipts SET ForkliftDriverID = StorekeeperID, VehicleDriver = NULL ", new ObjectParameter[] { });
            //}


            //this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "VoidTypeID", "int", null, false);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "InActive", "bit", "0", true);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "InActivePartial", "bit", "0", true);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "InActiveDate", "datetime", null, false);

            //this.totalSmartCodingEntities.ColumnAdd("SalesOrderDetails", "InActive", "bit", "0", true);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrderDetails", "InActivePartial", "bit", "0", true);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrderDetails", "InActiveDate", "datetime", null, false);

            //this.ExecuteStoreCommand("UPDATE ModuleDetails SET Code = N'Bin Locations', Name = N'Bin Locations' WHERE ModuleDetailID  = " + (int)GlobalEnums.NmvnTaskID.BinLocation, new ObjectParameter[] { });



            //if (!this.totalSmartCodingEntities.ColumnExists("BinLocations", "UserID"))
            //{
            //    this.totalSmartCodingEntities.ColumnAdd("BinLocations", "UserID", "int", "1", true);
            //    this.totalSmartCodingEntities.ColumnAdd("BinLocations", "PreparedPersonID", "int", "1", true);
            //    this.totalSmartCodingEntities.ColumnAdd("BinLocations", "OrganizationalUnitID", "int", "1", true);

            //    this.ExecuteStoreCommand("UPDATE BinLocations SET UserID = 11, PreparedPersonID = 11, OrganizationalUnitID = 5 WHERE LocationID = 1", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE BinLocations SET UserID = 32, PreparedPersonID = 32, OrganizationalUnitID = 7 WHERE LocationID = 2", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE BinLocations SET UserID = 33, PreparedPersonID = 33, OrganizationalUnitID = 16 WHERE LocationID = 3", new ObjectParameter[] { });



            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-28-1','104-28-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-28-2','104-28-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-29-1','104-29-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-29-2','104-29-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-30-1','104-30-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-30-2','104-30-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-31-1','104-31-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-31-2','104-31-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-32-1','104-32-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-32-2','104-32-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-33-1','104-33-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-33-2','104-33-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-34-1','104-34-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-34-2','104-34-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-35-1','104-35-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-35-2','104-35-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-36-1','104-36-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-36-2','104-36-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-37-1','104-37-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-37-2','104-37-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-38-1','104-38-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-38-2','104-38-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-25-1','104-25-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-23-2','104-23-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-24-1','104-24-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-24-2','104-24-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-23-1','104-23-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-26-1','104-26-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-25-2','104-25-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-26-2','104-26-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-27-1','104-27-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-27-2','104-27-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //}



            //this.ExecuteStoreCommand("UPDATE      AccessControls SET                AccessLevel = 0, ApprovalPermitted = 0, UnApprovalPermitted = 0, VoidablePermitted = 0, UnVoidablePermitted = 0, ShowDiscount = 0 WHERE        (UserID = 33)", new ObjectParameter[] { });

            //this.ExecuteStoreCommand("UPDATE      AccessControls SET                AccessLevel = 1, ApprovalPermitted = 0, UnApprovalPermitted = 0, VoidablePermitted = 0, UnVoidablePermitted = 0, ShowDiscount = 0 WHERE        (OrganizationalUnitID IN                            (SELECT        OrganizationalUnitID                           FROM            OrganizationalUnits                               WHERE        (LocationID = (SELECT        OrganizationalUnits.LocationID FROM            Users INNER JOIN                          OrganizationalUnits ON Users.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID WHERE        (Users.UserID = 33))))) AND (UserID = 33)", new ObjectParameter[] { });
            //this.ExecuteStoreCommand("UPDATE      AccessControls SET                AccessLevel = 2, ApprovalPermitted = 1, UnApprovalPermitted = 1, VoidablePermitted = 1, UnVoidablePermitted = 1, ShowDiscount = 0 WHERE        (OrganizationalUnitID IN                           (SELECT        OrganizationalUnitID                               FROM            OrganizationalUnits                              WHERE        (LocationID = (SELECT        OrganizationalUnits.LocationID FROM            Users INNER JOIN                          OrganizationalUnits ON Users.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID WHERE        (Users.UserID = 33))))) AND (UserID = 33)   and OrganizationalUnitID = (SELECT    OrganizationalUnitID FROM            Users WHERE        (UserID = 33))", new ObjectParameter[] { });


            //return;

            //if (!this.totalSmartCodingEntities.TableExists("EmployeeRoles"))
            //{

            //    this.ExecuteStoreCommand("CREATE TABLE [dbo].[EmployeeRoles]([EmployeeRoleID] [int] IDENTITY(1,1) NOT NULL, [EmployeeID] [int] NOT NULL, [RoleID] [int] NOT NULL, [InActive] [bit] NOT NULL, CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY CLUSTERED ([EmployeeRoleID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]");

            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 1, 0 FROM Employees WHERE EmployeeID = 1", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 2, 0 FROM Employees WHERE EmployeeID = 1", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 3, 0 FROM Employees WHERE EmployeeID = 1", new ObjectParameter[] { });

            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 2, 0 FROM Employees WHERE EmployeeID <> 1 AND (EmployeeID NOT IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 3, 0 FROM Employees WHERE (EmployeeID IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //}



            //if (!this.totalSmartCodingEntities.TableExists("EmployeeLocations"))
            //{

            //    this.ExecuteStoreCommand("CREATE TABLE [dbo].[EmployeeLocations]([EmployeeLocationID] [int] IDENTITY(1,1) NOT NULL, [EmployeeID] [int] NOT NULL, [LocationID] [int] NOT NULL, [InActive] [bit] NOT NULL, CONSTRAINT [PK_EmployeeLocations] PRIMARY KEY CLUSTERED ([EmployeeLocationID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]");

            //    this.ExecuteStoreCommand("INSERT INTO EmployeeLocations (EmployeeID, LocationID, InActive) SELECT EmployeeID, LocationID, 0 FROM Employees WHERE EmployeeID <> 1 AND (EmployeeID NOT IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });

            //    this.ExecuteStoreCommand("INSERT INTO EmployeeLocations (EmployeeID, LocationID, InActive) SELECT EmployeeID, 1, 0 FROM Employees WHERE EmployeeID = 1 OR (EmployeeID IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeLocations (EmployeeID, LocationID, InActive) SELECT EmployeeID, 2, 0 FROM Employees WHERE EmployeeID = 1 OR (EmployeeID IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeLocations (EmployeeID, LocationID, InActive) SELECT EmployeeID, 3, 0 FROM Employees WHERE EmployeeID = 1 OR (EmployeeID IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //}



            //var query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT TOP (200) COUNT(EmployeeID) AS Expr1 FROM Employees;", new object[] { });
            //int exists = query.Cast<int>().Single();
            //if (exists == 29)
            //{
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0109', N'Ngô Thanh Hương', N'', 1, 2)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0110', N'Nguyễn Ngọc Trinh', N'', 1, 2)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0111', N'Khúc Văn Huế', N'', 1, 2)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0112', N'Đàm Thị Thu Hiền', N'', 1, 2)", new ObjectParameter[] { });

            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0113', N'Le Thanh Nam', N'', 1, 3)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0114', N'Ngo Xuan Tho', N'', 1, 3)", new ObjectParameter[] { });


            //    this.ExecuteStoreCommand("UPDATE Locations SET OfficialName = N'260WH4' WHERE LocationID = 2", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE Locations SET OfficialName = N'700WH4' WHERE LocationID = 3", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE Locations SET OfficialName = N'500WH1' WHERE LocationID = 4", new ObjectParameter[] { });
            //}


            //query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT TOP (200) COUNT(CommodityCategoryID) AS Expr1 FROM CommodityCategories;", new object[] { });
            //exists = query.Cast<int>().Single();
            //if (exists == 1)
            //{
            //    this.ExecuteStoreCommand("INSERT INTO CommodityCategories (Name) SELECT [Loại SP] FROM A_Commodities_ShortName GROUP BY [Loại SP] ORDER BY [Loại SP]", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE CommodityCategories SET Name = N'Unknown' WHERE CommodityCategoryID = 2", new ObjectParameter[] { });

            //    this.ExecuteStoreCommand("UPDATE Commodities SET Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID FROM            Commodities INNER JOIN                         A_Commodities_ShortName ON Commodities.Code = A_Commodities_ShortName.Code INNER JOIN                         CommodityCategories ON A_Commodities_ShortName.[Loại SP] = CommodityCategories.Name", new ObjectParameter[] { });
            //}




            //query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT TOP (200) COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = 800001;", new object[] { });
            //exists = query.Cast<int>().Single();
            //if (exists == 0)
            //{
            //    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(800001, 6, 'AvailableItems', 'Available Items', '#', '#', '#', 1, 60, 1, 0)", new ObjectParameter[] { });
            //}

        }
        #endregion Backup for update log








































        #region Base Repository

        public int? GetStoredID(int configID)
        {
            return this.TotalSmartCodingEntities.GetStoredID(configID).Single();
        }

        public int? GetVersionID(int configID)
        {
            return this.TotalSmartCodingEntities.GetVersionID(configID).Single();
        }

        public bool VersionValidate(int configID, int configVersionID)
        {
            int? versionID = this.GetVersionID(configID);
            if (versionID == null || (int)versionID != configVersionID) throw new Exception("This program on your computer is not the latest version." + "\r\n" + "\r\n" + "Please exit and re-open your program again in order to update new version." + "\r\n" + "Contact your admin for more information. Thank you!" + "\r\n" + "\r\n" + "Phần mềm vừa được cập nhật phiên bản mới." + "\r\n" + "Vui lòng đóng và sau đó mở lại phần mềm để cập nhật phiên bản mới nhất. Cám ơn.");
            return true;
        }

        public int GetModuleID(GlobalEnums.NmvnTaskID nmvnTaskID)
        {
            var moduleDetail = this.totalSmartCodingEntities.ModuleDetails.Where(w => w.ModuleDetailID == (int)nmvnTaskID).FirstOrDefault();
            return moduleDetail != null ? moduleDetail.ModuleID : 0;
        }

        /// <summary>
        ///     Detect whether the context is dirty (i.e., there are changes in entities in memory that have
        ///     not yet been saved to the database).
        /// </summary>
        /// <param name="context">The database context to check.</param>
        /// <returns>True if dirty (unsaved changes); false otherwise.</returns>
        public bool IsDirty()
        {
            //Contract.Requires<ArgumentNullException>(context != null);

            // Query the change tracker entries for any adds, modifications, or deletes.
            IEnumerable<DbEntityEntry> res = from e in this.totalSmartCodingEntities.ChangeTracker.Entries()
                                             where e.State.HasFlag(EntityState.Added) ||
                                                 e.State.HasFlag(EntityState.Modified) ||
                                                 e.State.HasFlag(EntityState.Deleted)
                                             select e;

            var myTestOnly = res.ToList();

            if (res.Any())
                return true;

            return false;
        }


        public virtual ICollection<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters)
        {
            this.TotalBikePortalsObjectContext.CommandTimeout = 300;
            var objectResult = this.TotalBikePortalsObjectContext.ExecuteFunction<TElement>(functionName, parameters);

            return objectResult.ToList<TElement>();
        }

        public virtual int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            this.TotalBikePortalsObjectContext.CommandTimeout = 300;
            return this.TotalBikePortalsObjectContext.ExecuteFunction(functionName, parameters);
        }

        public virtual int ExecuteStoreCommand(string commandText, params Object[] parameters)
        {
            this.TotalBikePortalsObjectContext.CommandTimeout = 300;
            return this.TotalBikePortalsObjectContext.ExecuteStoreCommand(commandText, parameters);
        }




        public T GetEntity<T>(bool proxyCreationEnabled, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (!proxyCreationEnabled) this.totalSmartCodingEntities.Configuration.ProxyCreationEnabled = false;


            IQueryable<T> result = this.totalSmartCodingEntities.Set<T>();

            if (includes != null && includes.Any())
                result = includes.Aggregate(result, (current, include) => current.Include(include));


            T entity = null;

            if (predicate != null)
                entity = result.FirstOrDefault(predicate);
            else
                entity = result.FirstOrDefault();


            if (!proxyCreationEnabled) this.totalSmartCodingEntities.Configuration.ProxyCreationEnabled = true;


            return entity;
        }


        public T GetEntity<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntity<T>(true, predicate, includes);
        }

        public T GetEntity<T>(bool proxyCreationEnabled, params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntity<T>(proxyCreationEnabled, null, includes);
        }

        public T GetEntity<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntity<T>(null, includes);
        }






        public ICollection<T> GetEntities<T>(bool proxyCreationEnabled, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (!proxyCreationEnabled) this.totalSmartCodingEntities.Configuration.ProxyCreationEnabled = false;


            IQueryable<T> result = this.totalSmartCodingEntities.Set<T>();

            if (includes != null && includes.Any())
                result = includes.Aggregate(result, (current, include) => current.Include(include));

            ICollection<T> entities = null;

            if (predicate != null)
                entities = result.Where(predicate).ToList();
            else
                entities = result.ToList();



            if (!proxyCreationEnabled) this.totalSmartCodingEntities.Configuration.ProxyCreationEnabled = true;

            return entities;

        }

        public ICollection<T> GetEntities<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntities<T>(true, predicate, includes);
        }

        public ICollection<T> GetEntities<T>(bool proxyCreationEnabled, params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntities<T>(proxyCreationEnabled, null, includes);
        }

        public ICollection<T> GetEntities<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntities<T>(null, includes);
        }


        public string RepositoryTag { get; set; }
        public Dictionary<string, object> RepositoryBag { get; set; }



        #endregion Base Repository


    }
}
