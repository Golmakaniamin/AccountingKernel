using System.Collections;

namespace AccountingKernel.Forms.AssetGoods
{
    internal interface IItemsWrapper
    {
        IEnumerable Items { get; set; }
    }

    public class ItemsWrapper : IItemsWrapper
    {
        #region IItemsWrapper Members

        public IEnumerable Items { get; set; }

        #endregion
    }

    public class DetailItemsWrapper : ItemsWrapper{}

    public class InvoiceItemsWrapper:ItemsWrapper{}
}