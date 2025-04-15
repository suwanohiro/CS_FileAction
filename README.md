# FileAction

`FileAction` クラスは、相対パスを使用してファイルの読み書きを簡単に行うためのユーティリティクラスです。このクラスは、テキストファイルや CSV ファイルの操作をサポートしています。

## 主な機能

### 1. 相対パスを絶対パスに変換

- **メソッド名**: `ConvertFileLink`
- **説明**: 実行ファイルからの相対パスを絶対パスに変換します。
- **引数**: `currentFilePath` (相対パス)
- **戻り値**: 絶対パス

### 2. ファイルから文字列を読み取る

- **メソッド名**: `Read`
- **説明**: 指定されたファイルから文字列を読み取ります。
- **引数**: `currentFilePath` (相対パス)
- **戻り値**: ファイルの内容を文字列として返します。

### 3. ファイルから CSV データを読み取る

- **メソッド名**: `ReadCSV`
- **説明**: 指定された CSV ファイルを読み取り、二次元配列として返します。
- **引数**: `currentFilePath` (相対パス)
- **戻り値**: CSV データを格納した `List<List<string>>`

### 4. ファイルに文字列を書き込む

- **メソッド名**: `Write`
- **説明**: 指定されたファイルに文字列を書き込みます。
- **引数**:
  - `currentFilePath` (相対パス)
  - `writeString` (書き込む文字列)
  - `fileMode` (書き込みモード: `FileMode`)

### 5. ファイルに追記する

- **メソッド名**: `WriteAdd`
- **説明**: 指定されたファイルに文字列を追記します。
- **引数**:
  - `currentFilePath` (相対パス)
  - `writeString` (追記する文字列)

### 6. ファイルに上書きする

- **メソッド名**: `WriteNew`
- **説明**: 指定されたファイルに文字列を上書きします。
- **引数**:
  - `currentFilePath` (相対パス)
  - `writeString` (上書きする文字列)

### 7. ファイルの内容を削除する

- **メソッド名**: `Clear`
- **説明**: 指定されたファイルの内容を削除します。
- **引数**: `currentFilePath` (相対パス)

## 使用例

### ファイルから文字列を読み取る

```csharp
string content = FileAction.Read("example.txt");
Console.WriteLine(content);
```

### CSV ファイルを読み取る

```csharp
List<List<string>> csvData = FileAction.ReadCSV("data.csv");
foreach (var row in csvData)
{
    Console.WriteLine(string.Join(", ", row));
}
```

### ファイルに追記する

```csharp
FileAction.WriteAdd("example.txt", "\n追加のテキスト");
```

### ファイルの内容を削除する

```csharp
FileAction.Clear("example.txt");
```

## ライセンス

このプロジェクトは GNU General Public License v3.0 の下でライセンスされています。
