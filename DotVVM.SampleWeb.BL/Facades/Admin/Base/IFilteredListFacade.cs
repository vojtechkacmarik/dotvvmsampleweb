using DotVVM.Framework.Controls;

namespace DotVVM.SampleWeb.BL.Facades.Admin.Base
{
    public interface IFilteredListFacade<TDTO, TKey, TFilterDTO>
    {
        void FillDataSet(GridViewDataSet<TDTO> items, TFilterDTO filter);

        void Delete(TKey id);
    }
}