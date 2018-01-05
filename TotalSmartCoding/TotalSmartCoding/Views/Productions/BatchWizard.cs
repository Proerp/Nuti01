using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using Ninject;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Productions;
using TotalSmartCoding.Controllers.APIs.Productions;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Productions;
using TotalBase.Enums;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;


namespace TotalSmartCoding.Views.Productions
{
    public partial class BatchWizard : Form
    {
        private BatchViewModel batchViewModel;

        Binding bindingBatchMasterID;
        Binding bindingLotNumber;
        Binding bindingBatchTypeID;

        Binding bindingEntryDate;
        Binding bindingCommodityCode;
        Binding bindingCommodityName;
        Binding bindingCommodityAPICode;
        Binding bindingCommodityCartonCode;

        Binding bindingVolume;
        Binding bindingPlannedQuantity;
        Binding bindingPackQuantity;

        Binding bindingBatchStatusCode;
        Binding bindingRemarks;

        public BatchWizard(BatchViewModel batchViewModel)
        {
            InitializeComponent();

            this.batchViewModel = batchViewModel;
        }

        private void WizardMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.batchViewModel.PropertyChanged += batchDetailDTO_PropertyChanged;

                BatchMasterAPIs batchMasterAPIs = new BatchMasterAPIs(CommonNinject.Kernel.Get<IBatchMasterAPIRepository>());

                this.combexBatchMasterID.DataSource = batchMasterAPIs.GetBatchMasterBases();
                this.combexBatchMasterID.DisplayMember = CommonExpressions.PropertyName<BatchMasterBase>(p => p.Code);
                this.combexBatchMasterID.ValueMember = CommonExpressions.PropertyName<BatchMasterBase>(p => p.BatchMasterID);
                this.bindingBatchMasterID = this.combexBatchMasterID.DataBindings.Add("SelectedValue", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.BatchMasterID), true, DataSourceUpdateMode.OnPropertyChanged);

                BatchTypeAPIs batchTypeAPIs = new BatchTypeAPIs(CommonNinject.Kernel.Get<IBatchTypeAPIRepository>());
                this.combexBatchTypeID.DataSource = batchTypeAPIs.GetBatchTypeBases();
                this.combexBatchTypeID.DisplayMember = CommonExpressions.PropertyName<BatchTypeBase>(p => p.CodeName);
                this.combexBatchTypeID.ValueMember = CommonExpressions.PropertyName<BatchTypeBase>(p => p.BatchTypeID);
                this.bindingBatchTypeID = this.combexBatchTypeID.DataBindings.Add("SelectedValue", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.BatchTypeID), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingLotNumber = this.textexLotNumber.DataBindings.Add("Text", this.batchViewModel, "LotNumber", true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.EntryDate), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingCommodityCode = this.textexCommodityCode.DataBindings.Add("Text", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.CommodityCode), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingCommodityName = this.textexCommodityName.DataBindings.Add("Text", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.CommodityName), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingCommodityAPICode = this.textexCommodityAPICode.DataBindings.Add("Text", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.CommodityAPICode), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingCommodityCartonCode = this.textexCommodityCartonCode.DataBindings.Add("Text", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.CommodityCartonCode), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingVolume = this.numericVolume.DataBindings.Add("Value", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.Volume), false, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingPlannedQuantity = this.numericPlannedQuantity.DataBindings.Add("Value", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.PlannedQuantity), false, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingPackQuantity = this.numericPackQuantity.DataBindings.Add("Value", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.PackQuantity), false, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingBatchStatusCode = this.textexBatchStatusCode.DataBindings.Add("Text", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.BatchStatusCode), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.batchViewModel, CommonExpressions.PropertyName<BatchViewModel>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingBatchMasterID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingLotNumber.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingBatchTypeID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.bindingCommodityCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingCommodityName.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingCommodityAPICode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingCommodityCartonCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                
                this.bindingVolume.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingPlannedQuantity.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingPackQuantity.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.bindingBatchStatusCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.errorProviderMaster.DataSource = this.batchViewModel;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void batchDetailDTO_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.buttonOK.Enabled = this.batchViewModel.IsValid;
        }

        private void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Exception) { ExceptionHandlers.ShowExceptionMessageBox(this, e.ErrorText); e.Cancel = true; }
            if (sender.Equals(this.bindingBatchMasterID))
            {
                if (this.combexBatchMasterID.SelectedItem != null)
                {
                    BatchMasterBase batchMasterBase = (BatchMasterBase)this.combexBatchMasterID.SelectedItem;

                    this.batchViewModel.Code = batchMasterBase.Code;
                    this.batchViewModel.EntryDate = batchMasterBase.EntryDate;
                    this.batchViewModel.CommodityID = batchMasterBase.CommodityID;
                    this.batchViewModel.CommodityCode = batchMasterBase.CommodityCode;
                    this.batchViewModel.CommodityName = batchMasterBase.CommodityName;
                    this.batchViewModel.CommodityAPICode = batchMasterBase.CommodityAPICode;
                    this.batchViewModel.CommodityCartonCode = batchMasterBase.CommodityCartonCode;
                    this.batchViewModel.Shelflife = batchMasterBase.Shelflife;
                    this.batchViewModel.PackPerCarton = batchMasterBase.PackPerCarton;
                    this.batchViewModel.CartonPerPallet = batchMasterBase.CartonPerPallet;
                    this.batchViewModel.Volume = batchMasterBase.Volume;
                    this.batchViewModel.PlannedQuantity = batchMasterBase.PlannedQuantity;
                    this.batchViewModel.PackQuantity = batchMasterBase.PackQuantity;
                    this.batchViewModel.PackLineVolume = batchMasterBase.PackLineVolume;
                    this.batchViewModel.BatchStatusCode = batchMasterBase.BatchStatusCode;
                    this.batchViewModel.Remarks = batchMasterBase.Remarks;
                }
            }
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    if (this.batchViewModel.BatchMasterID != null)
                        this.DialogResult = DialogResult.OK;
                    else
                        CustomMsgBox.Show(this, "Vui lòng chọn khách hàng, nhân viên kinh doanh.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                }

                if (sender.Equals(this.buttonESC))
                    this.DialogResult = DialogResult.Cancel;


            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
    }
}
