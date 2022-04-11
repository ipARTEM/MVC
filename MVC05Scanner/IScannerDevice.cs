using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC06Scanner
{
    public interface IScannerDevice
    {
        Stream Scan();
    }
    public interface IScanOutputStrategy
    {
        void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
    }

    public sealed class ScannerContext
    {
        private readonly IScannerDevice _device;
        private IScanOutputStrategy _currentStrategy;
        public ScannerContext(IScannerDevice device)
        {
            _device = device;
        }
        public void SetupOutputScanStrategy(IScanOutputStrategy strategy)
        {
            _currentStrategy = strategy;
        }

        public void Execute(string outputFileName = "")
        {
            if (_device is null)
            {
                throw new ArgumentNullException("Не выбрано устройство.");
            }
            if (_currentStrategy is null)
            {
                throw new ArgumentNullException("Не выбрана стратегия сохранения скана в формат.");
            }
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                outputFileName = Guid.NewGuid().ToString();
            }
            _currentStrategy.ScanAndSave(_device, outputFileName);
        }
    }
    public sealed class PdfScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            Console.WriteLine("Работа по сканированию и сохранению в формат PDF.");
        }
    }
    public sealed class ImageScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            Console.WriteLine("Работа по сканированию и сохранению в формат Image.");
        }
    }
}
