using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Ninject;

using TotalBase;
using TotalDTO.Productions;
using TotalCore.Repositories.Productions;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Productions;
using TotalSmartCoding.Libraries;

namespace TotalSmartCoding.Views.Productions
{
    public partial class QuickView : Form
    {
        private ScannerAPIs scannerAPIs;

        public QuickView(IList<BarcodeDTO> barcodeList, string caption)
        {
            InitializeComponent();

            this.scannerAPIs = new ScannerAPIs(CommonNinject.Kernel.Get<IPackRepository>(), CommonNinject.Kernel.Get<ICartonRepository>(), CommonNinject.Kernel.Get<IPalletRepository>());

            this.fastBarcodes.SetObjects(barcodeList);

            this.Text = caption;
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            OLVHelpers.ApplyFilters(this.fastBarcodes, textFilter.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void fastBarcodes_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            e.Item.SubItems[0].Text = (e.RowIndex + 1).ToString();
        }

        private void fastBarcodes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                try
                {
                    if (this.fastBarcodes.SelectedObject != null)
                    {
                        int fillingLineID = 0; int cartonID = 0; int palletID = 0; int batchID = 0;

                        CartonDTO cartonDTO = this.fastBarcodes.SelectedObject as CartonDTO;
                        if (cartonDTO != null) { fillingLineID = cartonDTO.FillingLineID; cartonID = cartonDTO.CartonID; }

                        PalletDTO palletDTO = this.fastBarcodes.SelectedObject as PalletDTO;
                        if (palletDTO != null) { fillingLineID = palletDTO.FillingLineID; palletID = palletDTO.PalletID; }

                        if (fillingLineID > 0)
                        {
                            QuickView quickView = new QuickView(this.scannerAPIs.GetBarcodeList((GlobalVariables.FillingLine)fillingLineID, cartonID, palletID, batchID), (cartonDTO != null ? "Carton: " + cartonDTO.Code : (palletDTO != null ? "Pallet: " + palletDTO.Code : "")));
                            quickView.ShowDialog(); quickView.Dispose();
                        }
                    }
                }
                catch (Exception exception)
                {
                    ExceptionHandlers.ShowExceptionMessageBox(this, exception);
                }
            }
        }
    }
}
