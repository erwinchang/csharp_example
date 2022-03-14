# csharp_example

## 策略模式(Strategy Pattern)

- 說明:   
策略模式(Strategy Pattern)定義了演算法class，個別封裝起來，讓它們之間可以互相替換，此模式讓演算法的變動，不會影響到使用演算法的程式

- 適用情境:  
  1. 將變動部份抽離出來，用介面(合成)或抽像類別(繼承)宣告
  2. ex.存取資料來源可能是SQL Server或HBase，此時可以宣告iDataSource來各別實做


- 此範例
  1.依據SourceStrategy抽像類別
  2.分別實做二種類料庫來源(SQLSource/HBaseSource)
  3.利用動態置換技巧(setIFindString)


### 執行結果

```
按下SQL
String finding from SQL !!, FindWithSQL

按下HBase
String finding from HBase !!, FindWithHBase

按下Dynamic
String finding from BigData !!, FindWithBigData
String finding from BigData !!, FindWithBigData
```