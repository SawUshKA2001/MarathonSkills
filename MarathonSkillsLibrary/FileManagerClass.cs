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
        private string GetFilePath(string title, string filter, SaveFileDialog saveFile)
        {
            saveFile.Title = title;
            saveFile.Filter = filter;
            if (saveFile.ShowDialog() == true)
            {
                return saveFile.FileName;
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

        /// <summary>
        /// Выгрузка заданных данных в CSV файл
        /// </summary>
        /// <param name="data">
        /// Словарь с выгружаемыми данными
        /// </param>
        /// <returns>
        /// true - если выгрузка прошла успешно
        /// false - если выгрузка не произошла
        /// Exception("Произошла ошибка при сохранении данных") - если произошла ошибка
        /// </returns>
        public bool DownLoadToCsvFile(Dictionary<string, List<string>> data)
        {
            SaveFileDialog file = new SaveFileDialog();
            string nameFile = GetFilePath("Сохранение файла csv", "Text files(.csv)|.csv", file);
            if (nameFile != null)
            {
                try
                {
                    using (StreamWriter wr = new StreamWriter(nameFile))
                    {

                        wr.WriteLine(String.Join(";", data.Keys.ToList()));


                        List<List<string>> dataValues = data.Values.ToList();
                        for (int i = 0; i < dataValues[0].Count; i++)
                        {
                            List<string> dataRow = new List<string>();
                            foreach (var item in data.Keys.ToList())
                            {
                                dataRow.Add(data[item][i]);
                            }
                            wr.WriteLine(String.Join(";", dataRow));
                        }
                    }
                    return true;
                }
                catch
                {
                    throw new Exception("Произошла ошибка при сохранении данных");
                }
            }

            return false;
        }
    }
}
