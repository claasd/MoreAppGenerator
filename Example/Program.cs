using MoreAppBuilder;

var service = new MoreAppService(12345, "apiKey");
var folder = await service.Builder().Folder("folderID", "My forms").BuildAsync();
var form = folder.Form("myForm1", "Form number 1");
form.AddHeader("Header 1", HeaderElementSize.H1);
var photo = form.AddPhoto("p1", "Take a Photos").Required().FastUploadQuality().AllowDeviceSelection();
var photo2 = form.AddPhoto("p2", "Take a Photos").Required().FastUploadQuality().AllowDeviceSelection()
    .EnabledWhen(photo.HasValue());
await form.BuildAsync();