namespace DotVVM.SampleWeb.BL.Facades.Admin.Base
{
    public interface IDetailFacade<TDTO, TKey>
    {
        TDTO GetDetail(TKey id);
        TDTO InitializeNew();
        TDTO Save(TDTO item);
    }
}