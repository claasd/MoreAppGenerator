using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class CatalogueItem : InputElement<ICatalogueItem>, ICatalogueItem
{
    public CatalogueItem(string id, string label, DataSource? dataSource) : base("com.moreapps.plugins:catalogue:8", id, label, false)
    {
        Field.Properties["data_source_configuration"] = new SearchDataSource
        {
            Id = dataSource.Id,
            Mapping = new Dictionary<string, bool>()
            {
                { "id", true },
                { "name", true },
                { "description", true },
                { "priceExVat", true },
            }
        };
        SetCurrency("euro");
        Field.Properties["show_prices"] = false;
        Field.Properties["show_vat"] = false;
        Field.Properties["allow_remarks"] = false;
        Field.Properties["use_barcode_scanner"] = false;
        Field.Properties["vat_rate"] = 21;
    }

    public ICatalogueItem SetCurrency(string currency)
    {
        Field.Properties["currency"] = currency;
        return this;
    }

    public ICatalogueItem SetVatRate(double vatRate)
    {
        Field.Properties["vat_rate"] = vatRate;
        return this;
    }

    public ICatalogueItem ShowPrices()
    {
        Field.Properties["show_prices"] = true;
        return this;
    }

    public ICatalogueItem ShowVat()
    {
        Field.Properties["show_vat"] = true;
        return this;
    }

    public ICatalogueItem AllowRemarks()
    {
        Field.Properties["allow_remarks"] = true;
        return this;
    }

    public ICatalogueItem UseBarcodeScanner()
    {
        Field.Properties["use_barcode_scanner"] = true;
        return this;
    }
}