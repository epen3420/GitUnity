using System.Diagnostics;

namespace GitUnity
{
    public class CommandRunner
    {
        /// <summary>
        /// コマンドプロンプトでコマンドを実行
        /// </summary>
        /// <param name="command"></param>
        public void RunCommand(string dir, string command)
        {
            // プロセス設定
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // コマンドプロンプトを使用
                WorkingDirectory = dir,
                Arguments = $"/c {command}", // コマンド実行
                RedirectStandardOutput = true, // 標準出力をリダイレクト
                RedirectStandardError = true, // 標準エラーもリダイレクト
                UseShellExecute = false, // シェル実行を無効に
                CreateNoWindow = true // ウィンドウ非表示
            };

            Process process = new Process
            {
                StartInfo = processStartInfo
            };

            process.Start();

            // 標準出力と標準エラーの読み取り
            string errorOutput = process.StandardError.ReadToEnd();

            process.WaitForExit();
            process.Close();

<<<<<<< Updated upstream

        // コマンドと結果をログに表示
        UnityEngine.Debug.Log("Command: " + command);
        UnityEngine.Debug.Log("Output: " + output);

        if (!string.IsNullOrEmpty(errorOutput))
        {
            UnityEngine.Debug.LogError("Error: " + errorOutput);
=======
            if (!string.IsNullOrEmpty(errorOutput))
            {
                if (errorOutput.Contains("fatal") || errorOutput.Contains("error"))
                {
                    LogUtility.LogError(errorOutput);
                }
            }
>>>>>>> Stashed changes
        }
    }
}
