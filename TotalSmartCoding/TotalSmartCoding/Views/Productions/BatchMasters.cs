using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ninject;



using TotalSmartCoding.Views.Mains;


using TotalBase;
using TotalBase.Enums;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;

using TotalCore.Repositories.Productions;
using TotalSmartCoding.Controllers.APIs.Productions;
using TotalCore.Services.Productions;
using TotalSmartCoding.ViewModels.Productions;
using TotalSmartCoding.Controllers.Productions;
using TotalDTO.Productions;
using AutoMapper;
using TotalModel.Models;

using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;
using TotalModel.Interfaces;
using BrightIdeasSoftware;
using TotalSmartCoding.Properties;
using TotalSmartCoding.Views.Commons.Commodities;



namespace TotalSmartCoding.Views.Productions
{
    public partial class BatchMasters : BaseView
    {
        private BatchMasterAPIs batchMasterAPIs;
        private BatchMasterViewModel batchMasterViewModel { get; set; }

        public BatchMasters()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastBatchMasterIndex;


            this.batchMasterAPIs = new BatchMasterAPIs(CommonNinject.Kernel.Get<IBatchMasterAPIRepository>());

            this.batchMasterViewModel = CommonNinject.Kernel.Get<BatchMasterViewModel>();
            this.batchMasterViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.batchMasterViewModel;
        }

        protected override void NotifyPropertyChanged(string propertyName)
        {
            base.NotifyPropertyChanged(propertyName);

            if (propertyName == "ReadonlyMode")
            {
                this.buttonDiscontinued.Enabled = this.Newable && this.ReadonlyMode;
            }
        }

        protected override void InitializeTabControl()
        {
            try
            {
                this.comboDiscontinued.SelectedIndex = 0;

                CustomTabControl customTabBatchMaster = new CustomTabControl();
                //customTabControlCustomerChannel.ImageList = this.imageListTabControl;

                customTabBatchMaster.Font = this.textexCode.Font;
                customTabBatchMaster.DisplayStyle = TabStyle.VisualStudio;
                customTabBatchMaster.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

                customTabBatchMaster.TabPages.Add("BatchMaster", "Batch Information    ");
                customTabBatchMaster.TabPages[0].Controls.Add(this.layoutMaster);

                this.naviBarMaster.Bands[0].ClientArea.Controls.Add(customTabBatchMaster);

                customTabBatchMaster.Dock = DockStyle.Fill;
                this.layoutMaster.Dock = DockStyle.Fill;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        Binding bindingEntryDate;
        Binding bindingCode;

        Binding bindingPlannedQuantity;

        Binding bindingRemarks;

        Binding bindingCommodityID;
        Binding bindingBatchStatusID;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.batchMasterViewModel, "EntryDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingCode = this.textexCode.DataBindings.Add("Text", this.batchMasterViewModel, "Code", true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingPlannedQuantity = this.numericPlannedQuantity.DataBindings.Add("Value", this.batchMasterViewModel, CommonExpressions.PropertyName<BatchMasterViewModel>(p => p.PlannedQuantity), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.batchMasterViewModel, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged);

            this.textexCommodityAPICode.DataBindings.Add("Text", this.batchMasterViewModel, CommonExpressions.PropertyName<BatchMasterViewModel>(p => p.CommodityAPICode), true);
            this.textexCommodityName.DataBindings.Add("Text", this.batchMasterViewModel, CommonExpressions.PropertyName<BatchMasterViewModel>(p => p.CommodityName), true);

            CommodityAPIs commodityAPIs = new CommodityAPIs(CommonNinject.Kernel.Get<ICommodityAPIRepository>());
            this.combexCommodityID.DataSource = commodityAPIs.GetCommodityBases();
            this.combexCommodityID.DisplayMember = CommonExpressions.PropertyName<CommodityBase>(p => p.Code);
            this.combexCommodityID.ValueMember = CommonExpressions.PropertyName<CommodityBase>(p => p.CommodityID);
            this.bindingCommodityID = this.combexCommodityID.DataBindings.Add("SelectedValue", this.batchMasterViewModel, CommonExpressions.PropertyName<BatchMasterViewModel>(p => p.CommodityID), true, DataSourceUpdateMode.OnPropertyChanged);

            WarehouseAPIs warehouseAPIs = new WarehouseAPIs(CommonNinject.Kernel.Get<IWarehouseAPIRepository>());
            this.combexBatchStatusID.DataSource = warehouseAPIs.GetWarehouseBases();
            this.combexBatchStatusID.DisplayMember = CommonExpressions.PropertyName<WarehouseBase>(p => p.CodeAPICode);
            this.combexBatchStatusID.ValueMember = CommonExpressions.PropertyName<WarehouseBase>(p => p.WarehouseID);
            this.bindingBatchStatusID = this.combexBatchStatusID.DataBindings.Add("SelectedValue", this.batchMasterViewModel, CommonExpressions.PropertyName<BatchMasterViewModel>(p => p.BatchStatusID), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingPlannedQuantity.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingCommodityID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingBatchStatusID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.fastBatchMasterIndex.AboutToCreateGroups += fastBatchMasterIndex_AboutToCreateGroups;

            this.fastBatchMasterIndex.ShowGroups = true;
        }

        private void fastBatchMasterIndex_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Storage32";
                    olvGroup.Subtitle = olvGroup.Contents.Count.ToString() + " Lot(s)";
                }
            }
        }

        protected override void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            base.CommonControl_BindingComplete(sender, e);
            if (sender.Equals(this.bindingCommodityID))
            {
                if (this.combexCommodityID.SelectedItem != null)
                {
                    CommodityBase commodityBase = (CommodityBase)this.combexCommodityID.SelectedItem;
                    this.batchMasterViewModel.CommodityName = commodityBase.Name;
                    this.batchMasterViewModel.CommodityAPICode = commodityBase.APICode;
                }
            }
        }

        private BatchMasterController batchMasterController
        {
            get { return new BatchMasterController(CommonNinject.Kernel.Get<IBatchMasterService>(), this.batchMasterViewModel); }
        }

        protected override Controllers.BaseController myController
        {
            get { return this.batchMasterController; }
        }

        public override void Loading()
        {
            this.fastBatchMasterIndex.SetObjects(this.batchMasterAPIs.GetBatchMasterIndexes(this.comboDiscontinued.SelectedIndex == 0 ? GlobalEnums.ActiveOption.Active : GlobalEnums.ActiveOption.Both));
            base.Loading();
        }

        protected override void DoAfterLoad()
        {
            base.DoAfterLoad();
            this.fastBatchMasterIndex.Sort(this.olvEntryDate, SortOrder.Ascending);
        }

        private void comboDiscontinued_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.batchMasterAPIs != null) this.Loading();
        }

        private void fastBatchIndex_FormatRow(object sender, FormatRowEventArgs e)
        {
            BatchMasterIndex batchMasterIndex = (BatchMasterIndex)e.Model;
            if (batchMasterIndex.InActive) e.Item.ForeColor = Color.Gray;
        }

        protected override bool ApproveCheck(int id)
        {
            return !this.batchMasterViewModel.IsDefault && !this.batchMasterViewModel.InActive;
        }

        private void buttonDiscontinued_Click(object sender, EventArgs e)
        {
            this.Void();
        }

        protected override bool VoidCheck(int id)
        {
            this.batchMasterViewModel.VoidTypeID = 1;
            return !this.batchMasterViewModel.IsDefault;
        }

        private void buttonItems_Click(object sender, EventArgs e)
        {
            try
            {
                MasterMDI masterMDI = new MasterMDI(GlobalEnums.NmvnTaskID.Commodity, new Commodities());

                masterMDI.ShowDialog();
                masterMDI.Dispose();
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }



    }
}
