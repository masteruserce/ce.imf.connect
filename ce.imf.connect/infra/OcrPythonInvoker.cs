using System.Diagnostics;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ce.imf.connect.infra
{
    public class OcrResult
    {
        public string Word { get; set; }
        public float Confidence { get; set; }
        public Position Position { get; set; }
    }

    public class Position
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class OcrPythonInvoker
    {
        private readonly string _pythonExe;
        private readonly string _scriptPath;

        public OcrPythonInvoker(string pythonExe, string scriptPath)
        {
            _pythonExe = pythonExe;
            _scriptPath = scriptPath;
        }

        public async Task<List<OcrResult>> ExtractTextAsync(string imagePath)
        {
            var psi = new ProcessStartInfo
            {
                FileName = _pythonExe,
                Arguments = $"\"{_scriptPath}\" \"{imagePath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8
            };

            using var process = Process.Start(psi);
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
                throw new System.Exception($"Python error: {error}");

            // Expecting output as JSON array
            return JsonSerializer.Deserialize<List<OcrResult>>(output);
        }
    }
}