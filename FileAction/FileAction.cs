using System.Text;

public class FileAction
{
    /// <summary>
    /// 相対パスを絶対パスに変換する
    /// </summary>
    /// <param name="currentFilePath">実行ファイルからの相対パス</param>
    /// <returns>絶対パス</returns>
    public static string ConvertFileLink(string currentFilePath)
    {
        string baseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string absolutePath = Path.GetFullPath(Path.Combine(baseDir, currentFilePath));
        return absolutePath;
    }

    /// <summary>
    /// ファイルから文字列を読み取る
    /// </summary>
    /// <param name="currentFilePath">実行ファイルからの相対パス</param>
    /// <returns>読み取った文字列</returns>
    public static string Read(string currentFilePath)
    {
        string absolutePath = ConvertFileLink(currentFilePath);
        using (StreamReader reader = new StreamReader(absolutePath, Encoding.UTF8))
        {
            string result = reader.ReadToEnd();
            return result;
        }
    }

    /// <summary>
    /// ファイルからcsvデータを読み取る
    /// </summary>
    /// <param name="currentFilePath">実行ファイルからの相対パス</param>
    /// <returns>csvデータを読み取った二次元配列</returns>
    public static List<List<string>> ReadCSV(string currentFilePath)
    {
        string textData = Read(currentFilePath);
        List<List<string>> result = new List<List<string>>();
        string[] lines = textData.Split('\n');
        foreach (string line in lines)
        {
            string[] columns = line.Split(',');
            result.Add(new List<string>(columns));
        }
        return result;
    }

    /// <summary>
    /// ファイルに書き込む
    /// </summary>
    /// <param name="currentFilePath">実行ファイルからの相対パス</param>
    /// <param name="writeString">書き込む文字列</param>
    /// <param name="fileMode">書込モード</param>
    public static void Write(string currentFilePath, string writeString, FileMode fileMode)
    {
        string absolutePath = ConvertFileLink(currentFilePath);
        using (StreamWriter writer = new StreamWriter(absolutePath, false, Encoding.UTF8))
        {
            writer.Write(writeString);
        }
    }

    /// <summary>
    /// ファイルに書き込む (追記)
    /// </summary>
    /// <param name="currentFilePath">実行ファイルからの相対パス</param>
    /// <param name="writeString">書き込む文字列</param>
    public static void WriteAdd(string currentFilePath, string writeString)
    {
        Write(currentFilePath, writeString, FileMode.Append);
    }

    /// <summary>
    /// ファイルに書き込む (上書き)
    /// </summary>
    /// <param name="currentFilePath">実行ファイルからの相対パス</param>
    /// <param name="writeString">書き込む文字列</param>
    public static void WriteNew(string currentFilePath, string writeString)
    {
        Write(currentFilePath, writeString, FileMode.Create);
    }

    /// <summary>
    /// ファイルの内容を削除する
    /// </summary>
    /// <param name="currentFilePath">実行ファイルからの相対パス</param>
    public static void Clear(string currentFilePath)
    {
        WriteNew(currentFilePath, "");
    }
}
