using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace MVC08Template
{
    public static   class R
    {
        private static bool _exit = true;
        private static string _getPath = null;
        private static string _pathOld;
        private static string _pathNew;

        public static List<DriveInfoSave> infoSaves { get; set; } = new List<DriveInfoSave>();

        public static  DriveInfoSave driveInfoSave { get; set; }
        public static  void Run()
        {
            do
            {
                Console.WriteLine(_allCommand[0]);
                Console.Write(PathLine.GetPath(_getPath));
                Console.Write(">>");

                Input(Console.ReadLine());
                Console.WriteLine();
            } while (_exit);
        }

        private static  async void Input(string str)
        {
            str = str.ToLower();
            switch (str)
            {

                case "help":
                    foreach (var i in _allCommand)
                    {
                        Console.WriteLine(i);
                    }
                    break;

                case "q":
                    _exit = false;
                    break;

                case "d":
                    foreach (var i in PathLine.GetDrives())
                    {
                        Console.WriteLine(i);
                    }
                    break;

                case "show":
                    Console.WriteLine(@"Введите адрес каталога в формате 'd:\folder\subfolder'");
                    string str2 = Console.ReadLine();
                    PathLine.GetShow(@$"{str2}");
                    break;

                case "cd":
                    Console.WriteLine("Введите путь к переходу в новую директорию");
                    _getPath = PathLine.GetPath(Console.ReadLine());
                    break;

                case "null":
                    _getPath = null;
                    break;

                case "nc":
                    if (_getPath == null)
                    {
                        Console.WriteLine("Не указана директория, где создать новую папку");
                    }
                    else
                    {
                        Console.WriteLine("Введите название папки");
                        _getPath = PathLine.CreateCatalog(_getPath, Console.ReadLine());
                    }
                    break;

                case "nf":
                    if (_getPath == null)
                    {
                        Console.WriteLine("Не указана директория, где сохранить новый файл");
                    }
                    else
                    {
                        Console.WriteLine("Введите название и расширение файла в формате 'text.txt'");
                        PathLine.CreateFile(_getPath, Console.ReadLine());
                    }

                    break;

                case "dc":
                    if (_getPath == null)
                    {
                        Console.WriteLine("Не указанна директория, где хранится папка");
                    }
                    else
                    {
                        Console.WriteLine("Введите название папки для удаления");
                        PathLine.DeleteCatalog(_getPath, Console.ReadLine());
                    }
                    break;

                case "df":
                    if (_getPath == null)
                    {
                        Console.WriteLine("Не удаётся найти директорию, из которой удалить файл");
                    }
                    else
                    {
                        Console.WriteLine("Введите название и расширение файла в формате для удаления 'text.txt'");
                        PathLine.DeleteFile(_getPath, Console.ReadLine());
                    }
                    break;

                case "mf":
                    Console.WriteLine(@"Введите название файла для перемещения в формате 'd:\folder\text.txt'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Введите название файла, куда переместить в формате 'd:\folder\text.txt'");
                    _pathNew = Console.ReadLine();

                    PathLine.MoveToFile(_pathOld, _pathNew);
                    break;

                case "mc":
                    Console.WriteLine(@"Введите название папки для перемещения в формате 'd:\folder\text'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Введите название новой папки, куда переместить в формате 'd:\folder\text'");
                    _pathNew = Console.ReadLine();

                    PathLine.MoveToCatalog(_pathOld, _pathNew);
                    break;

                case "rc":
                    Console.WriteLine(@"Введите название папки, которую надо переименовать в формате 'd:\folder\text'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Введите название новой папки в формате 'd:\folder\text'");
                    _pathNew = Console.ReadLine();

                    PathLine.RenameCatalog(_pathOld, _pathNew);
                    break;

                case "rf":
                    Console.WriteLine(@"Введите название файла, который надо переименовать в формате 'd:\folder\text.txt'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Введите название файла, в который надо переименовать в формате 'd:\folder\text.txt'");
                    _pathNew = Console.ReadLine();

                    PathLine.RenameFile(_pathOld, _pathNew);
                    break;

                case "cc":
                    Console.WriteLine(@"Введите название папки, которую надо копировать в формате 'd:\folder\text'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Введите название новой папки, который надо создать в формате 'd:\folder\text'");
                    _pathNew = Console.ReadLine();

                    PathLine.CopyCatalog(_pathOld, _pathNew);
                    break;

                case "cf":
                    Console.WriteLine(@"Введите название файла, который надо копировать в формате 'd:\folder\text.txt'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Введите название нового файла, который надо создать при копировании в формате 'd:\folder\text.txt'");
                    _pathNew = Console.ReadLine();

                    PathLine.CopyFile(_pathOld, _pathNew);
                    break;

                case "gc":
                    Console.WriteLine(@"Произвести поиск папок по маске в папке в формате 'd:\folder\text'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Указать часть папки в формате 'c*'");
                    _pathNew = Console.ReadLine();

                    PathLine.GetFullDirectories(_pathOld, _pathNew);
                    break;

                case "gf":
                    Console.WriteLine(@"Произвести поиск файлов по маске в папке в формате 'd:\folder\text'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Произвести поиск файлов по маске файлов в формате '*.txt'");
                    _pathNew = Console.ReadLine();

                    PathLine.GetFullFiles(_pathOld, _pathNew);
                    break;


                case "ic":
                    Console.WriteLine(@"Введите адрес папки для вычесления размера в формате 'd:\folder\text'");
                    _pathOld = Console.ReadLine();


                    PathLine.InfoCatalog(_pathOld);
                    break;


                case "if":
                    Console.WriteLine(@"Введите адрес файла для вычисления данных о файле в формате 'd:\folder\text.txt'");
                    _pathOld = Console.ReadLine();

                    PathLine.InfoFile(_pathOld);
                    break;



                case "sf":
                    Console.WriteLine(@"Введите адрес файла в формате 'd:\folder\text.txt'");
                    _pathOld = Console.ReadLine();

                    PathLine.TextFileStatistics(_pathOld);
                    break;


                case "af":
                    Console.WriteLine(@"Введите адрес файла для изменения атрибута только для чтения в формате 'd:\folder\text.txt'");
                    _pathOld = Console.ReadLine();

                    Console.WriteLine(@"Передайте параметр  для файла 'f'-не активен только для чтения, 't'- активен только для чтения");
                    _pathNew = Console.ReadLine();

                    PathLine.AttributeFile(_pathOld, _pathNew);
                    break;

                case "dr":
                    DiskReport();
                    break;

                default:
                    break;
            }
        }

        private static List<string> _allCommand = new List<string>()
        {
            "help - выводит справочную информацию о командах",
            "q- выход из программы",
            "d- показать диски",
            "show -показать содержимое диска или папки",
            "'null' - выйти из каталога",
            @"'cd' затем 'C:\Windows'- переход в данный каталог",
            "'nc'- создать новую папку в данной директории",
            "'nf'- создать новый файл в данной директории",
            "'dc'- удалить папку в данной директории",
            "'df'- удалить файл в данной директории",
            "'mf'- переместить файл",
            "'mc'- переместить папку",
            "'rf'- переименовать файл",
            "'cc'- копировать папку",
            "'cf'- копировать файл",
            "'gc'- поиск папок по маске",
            "'gf'- поиск файлов по маске",
            "'ic'- вычислить размер папки",
            "'if'- вычислить размер файла",
            "'sf'- статистические данные о файле",
            "'af'- установить/удалить атрибут только для чтения в файле",
            "'dr'- отчёт по использованию дисков",

        };


        /// <summary>
        /// Отчёт по дискам
        /// </summary>
        public static void DiskReport()
        {
            Console.WriteLine("Отчет по дискам:");
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                driveInfoSave = new DriveInfoSave();
                Console.WriteLine($"Название: {drive.Name}");
                driveInfoSave.Name = drive.Name;

                Console.WriteLine($"Тип: {drive.DriveType}");
                driveInfoSave.DriveType = drive.DriveType;
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    driveInfoSave.TotalSize = drive.TotalSize;
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    driveInfoSave.TotalFreeSpace = drive.TotalFreeSpace;
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                    driveInfoSave.VolumeLabel = drive.VolumeLabel;
                }
             
                Console.WriteLine();
                infoSaves.Add(driveInfoSave);
            }
            TemplateMicrosoftWord(infoSaves);
        }

        private static void TemplateMicrosoftWord(List<DriveInfoSave> infoSave, string output="")
        {
            if (infoSave is null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(output))
            {
                output = Path.Combine(Directory.GetCurrentDirectory(),
                "DriveInfoSave01.docx");
            }
            if (File.Exists(output))
            {
                File.Delete(output);
            }
            //File.Copy("D:\\Программирование\\GeekBrains\\ASP.NET MVC Core\\MVC\\Report01.docx", output);
            File.Copy("Report01.docx", output);
            List<TableRowContent> rows = new List<TableRowContent>();

            foreach (DriveInfoSave drive in infoSave)
            {
                rows.Add(new TableRowContent(new List<FieldContent>()
                {
                    new FieldContent("Field Name",drive.Name),
                    new FieldContent("Field DriveType",drive.DriveType.ToString()),
                    new FieldContent("Field TotalSize",drive.TotalSize.ToString()),
                    new FieldContent("Field TotalFreeSpace",drive.TotalFreeSpace.ToString()),
                    new FieldContent("Field VolumeLabel",drive.VolumeLabel.ToString()),
                }));
            }
 
            
            var valuesToFill = new Content(
           
            TableContent.Create("Lines", rows)
            );

            using (var outputDocument = new TemplateProcessor(output)
            .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }

        }

    }

    public class DriveInfoSave
    {
        public string Name { get; set; }
        public DriveType DriveType { get; set; }
        public long TotalSize { get; set; }
        public long TotalFreeSpace { get; set; }
        public string VolumeLabel { get; set; }

    }

   
}
