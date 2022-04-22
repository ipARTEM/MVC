

using MVC06Scanner;

PdfScanOutputStrategy pdf = new PdfScanOutputStrategy();
ImageScanOutputStrategy image = new ImageScanOutputStrategy();

Device device = new Device();

Console.WriteLine(device.Scan());

ScannerContext scanner= new ScannerContext(device);

scanner.SetupOutputScanStrategy(pdf);
scanner.Execute();

scanner.SetupOutputScanStrategy(image);
scanner.Execute();




