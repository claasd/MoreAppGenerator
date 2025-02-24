namespace MoreAppBuilder.Implementation;

internal class FileElement : InputElement<IFileElement>, IFileElement
{
    internal FileElement(string id, string label) : base( "com.moreapps.plugins:file:7", id, label, false)
    {
        Field.Properties["allowed_file_type"] = "documents";
    }

    public IFileElement ForDocuments()
    {
        Field.Properties["allowed_file_type"] = "documents";
        return this;
    }

    public IFileElement ForImages()
    {
        Field.Properties["allowed_file_type"] = "images";
        return this;
    }

    public IFileElement ForAudio()
    {
        Field.Properties["allowed_file_type"] = "audio";
        return this;
    }

    public IFileElement ForVideo()
    {
        Field.Properties["allowed_file_type"] = "video";
        return this;
    }
}