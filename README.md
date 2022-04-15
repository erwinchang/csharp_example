# csharp_example

## [Select a USB Serial Device via its VID/PID][1]


缺點: 系統中有記錄的都找出來(即沒有實際插著也有)  

測試記錄  

```
s3:FTDIBUS
s:VID_0403+PID_6001+A10JTAFMA
==Entry==
s2:0000
**** name:COM4
s:VID_0403+PID_6001+AL00N6W4A
==Entry==
s2:0000
**** name:COM3
s:VID_0403+PID_6001+AR0K9PDMA
==Entry==
s2:0000
**** name:COM7
s:VID_0403+PID_6001+AR0KAUUDA
==Entry==
s2:0000
**** name:COM9
```

測試記錄  

```
s3:USB
s:ROOT_HUB20
s:ROOT_HUB30
s:VID_0000&PID_0002
s:VID_0000&PID_0004
s:VID_0403&PID_6001
==Entry==
s2:A10JTAFM
**** name:
s2:AL00N6W4
**** name:
s2:AR0K9PDM
**** name:
s2:AR0KAUUD
**** name:
```

測試記錄結果  

```
-- name:COM4
-- name:COM3
-- name:COM7
-- name:COM9
-- name:
-- name:
-- name:
-- name:
```

<a href="https://imgur.com/NFOFBvh"><img src="https://i.imgur.com/NFOFBvh.png" title="source: imgur.com" width="400px" /></a>

<a href="https://imgur.com/bFnnlHy"><img src="https://i.imgur.com/bFnnlHy.png" title="source: imgur.com" width="400px" /></a>

------------

實際使用的COM   
```
Name:USB Serial Port (COM7), Manufacturer:FTDI
```


[1]:https://www.codeproject.com/Tips/349002/Select-a-USB-Serial-Device-via-its-VID-PID