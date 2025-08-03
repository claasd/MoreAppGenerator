namespace MoreAppBuilder.Implementation;

internal class PhotoElement : InputElement<IPhotoElement>, IPhotoElement
{
    public enum PhotoQuality {
        Best,
        High,
        Fast
    }
    public PhotoElement(string id, string label, PhotoQuality quality = PhotoQuality.High) : base("com.moreapps:photo:1", id, label, false)
    {
        Field.Properties["data_name"] = id.Trim();
        Field.Properties["label_text"] = label.Trim();
        Field.Properties["required"] = false;
        Field.Properties["quality"] = "best";
        Field.Properties["allow_library"] = false;
        Field.Properties["full_size_preview"] = false;
        Field.Properties["save_to_gallery"] = false;
        Field.Properties["quality"] = quality.ToString().ToLower();
    }

    public IPhotoElement Id(string identifier)
    {
        Field.Properties["data_name"] = identifier.Trim();
        return this;
    }

    public IPhotoElement Label(string label)
    {
        Field.Properties["label_text"] = label.Trim();
        return this;
    }

    public IPhotoElement Required()
    {
        Field.Properties["required"] = true;
        return this;
    }

    public IPhotoElement BestQuality()
    {
        Field.Properties["quality"] = nameof(PhotoQuality.Best).ToLower();
        return this;
    }

    public IPhotoElement HighQuality()
    {
        Field.Properties["quality"] = nameof(PhotoQuality.High).ToLower();
        return this;
    }

    public IPhotoElement FastUploadQuality()
    {
        Field.Properties["quality"] = nameof(PhotoQuality.Fast).ToLower();
        return this;
    }

    public IPhotoElement AllowDeviceSelection()
    {
        Field.Properties["allow_library"] = true;
        return this;
    }
}