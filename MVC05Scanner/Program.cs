

using MVC06Scanner;

IScannerDevice device ;

PdfScanOutputStrategy pdfScan=new PdfScanOutputStrategy ();

pdfScan.ScanAndSave(device,"sd");

ScannerContext scanner = new ScannerContext(pdfScan);

