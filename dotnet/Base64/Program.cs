using System.Buffers.Text;
using System.Text;

byte[] data = Encoding.UTF8.GetBytes("Hello NDC, how are you all doing?");

var base64Url = Base64Url.EncodeToString(data);
var base64 = Convert.ToBase64String(data);

Console.WriteLine(base64Url);
Console.WriteLine(base64);