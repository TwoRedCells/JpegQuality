JpegQuality
===========

[Read about how `JpegQuality` works on CodeProject.](http://www.codeproject.com/Articles/868207/Drag-and-Drop-Tool-to-Reduce-JPEG-Quality-and-file)

Overview
--------

Make a lower-quality copy of multiple JPEG files. This is useful when you have shot
lots of high-quality, high-resolution images that are not important enough to store
at their original size. These results are typical:

Quality  |  Size relative to original
---------|----------------------------
95       | 50%
90       | 30%
80       | 20%
70       | 15%
60       | 12%
50       | 10%
40       | 9%
30       | 8%
20       | 7%
10       | 5%
5        | 4%

Requirements
------------
* Windows XP or later
* .NET Framework 3.5 or later

Usage
-----
* To set the quality value, run `JpegQuality.exe` and select a value from the drop-down.
  This value is saved to the registry for future use.
* Drag-and-drop file(s) directly onto `JpegQuality.exe`; or
* Run `JpegQuality.exe` and drag-and-drop file(s) where indicated.
* New files will be saved in the same location as the originals, with `-XX` appended,
  where XX is the quality factor.

Download Binaries
-----------------
[Download the ready-to-use binary.](https://github.com/TwoRedCells/JpegQuality/blob/master/Binaries/JpegQuality.exe?raw=true)

