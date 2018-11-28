using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace WinAppJPEGCompression
{
    class ImageClass
    {
        public void SetJPEGCompression(string FullFilePath, long level)
        {
            string NewFile = string.Empty;
            using (Bitmap bmp1 = new Bitmap(FullFilePath))
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID  
                // for the Quality parameter category.  
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.  
                // An EncoderParameters object has an array of EncoderParameter  
                // objects. In this case, there is only one  
                // EncoderParameter object in the array.  
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, level);
                myEncoderParameters.Param[0] = myEncoderParameter;
                NewFile = FullFilePath + "_optimized";
                bmp1.Save(NewFile, jpgEncoder, myEncoderParameters);
            }
            File.Delete(FullFilePath);
            File.Move(NewFile, FullFilePath);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
