using Microsoft.Win32;
using System;
using System.IO;

namespace WindowsFormsApplication1
{
    class WorkWithFolder 
    {
        private string addressOfCurrentFolder; // адрес введенной нами папки
        private string addressOfExtensions = @"Extensions\"; // относительный адрес папки с расширениями
        private string newAddress;  // новые адреса для файлов

        public WorkWithFolder(string address)
        {
            this.addressOfCurrentFolder = address;
            go();
            
        }

        private string getAddressOfFolderFromRegistry(string value) // новые адреса это папки библиотек, получаем их местонахождение из реестра
        {
            string myAddress = "";
            string addressOnRegistry = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(addressOnRegistry);
                myAddress = registryKey.GetValue(value).ToString();
                registryKey.Close();
            }
            catch
            {
                ArgumentException e;
            }
            return myAddress;
        }

        private void go()
        {
            foreach (string name in Directory.GetFiles(addressOfExtensions)) 
            {
                string lineInFile;
                StreamReader streamReader = new StreamReader(name);
                newAddress = getAddressOfFolderFromRegistry(Path.GetFileNameWithoutExtension(name));
                while ((lineInFile = streamReader.ReadLine()) != null)
                {
                    foreach (string nameOfFileWithThisExtension in Directory.GetFiles(addressOfCurrentFolder, lineInFile))
                    {
                        string newFileNameWithAddress = Path.Combine(newAddress, Path.GetFileName(nameOfFileWithThisExtension));
                        File.Move(nameOfFileWithThisExtension, newFileNameWithAddress);
                    }
                }
            }
        }
    }
}
