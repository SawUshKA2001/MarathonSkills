using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MarathonSkillsLibrary
{
    public class FileManagerClass
    {
        private string GetFilePath(string title, string filter, OpenFileDialog openFile)
        {
            openFile.Title = title;
            openFile.Filter = filter;
            if (openFile.ShowDialog() == true)
            {
                return openFile.FileName;
            }
            else
            {
                return null;
            }
        }

        public string GetPhotoPath()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            return GetFilePath("Выберите фотографию", "PNG file(*.png)|*.png|JPEG file(*.jpeg)|*.jpeg|JPG file(*.jpg)|*.jpg", openFile);
        }

        public static BitmapImage GetPhotoImage(string photoPath)
        {
            if (photoPath != null)
            {
                try
                {
                    return new BitmapImage(new Uri(photoPath));
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public byte[] GetBytePhoto(string photoPath)
        {
            try
            {
                return File.ReadAllBytes(photoPath);
            }
            catch
            {
                return null;
            }
        }

        public static BitmapImage GetBytePhotoToImage(byte[] bytePhoto)
        {
            if (bytePhoto != null)
            {
                MemoryStream ms = new MemoryStream(bytePhoto);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
            else 
            {
                return null;
            }
        }


    }
}
