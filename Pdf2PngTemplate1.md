# csharp_example

### Pdf2PngTemplate1

.pdf to png  

```
                string pdfFile = @"D:\template7_1.pdf";
                string page1File = @"D:\template7_1_page1.png";
                byte[] bitmap;
                using (FileStream fs = File.Open(pdfFile, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    bitmap = Freeware.Pdf2Png.Convert(fs, 1);
                }
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
                BitmapImage bimage = LoadImage(bitmap);
                Save2Png(bimage, page1File);
```

- [Convert PDF to PNG's with Freeware.Pdf2Png][1]
- [Convert byte array to image in wpf][2]
- [How do I save a BitmapImage from memory into a file in WPF C#?][3]


[1]:https://stackoverflow.com/questions/77946656/convert-pdf-to-pngs-with-freeware-pdf2png
[2]:https://stackoverflow.com/questions/9564174/convert-byte-array-to-image-in-wpf
[3]:https://stackoverflow.com/questions/35804375/how-do-i-save-a-bitmapimage-from-memory-into-a-file-in-wpf-c