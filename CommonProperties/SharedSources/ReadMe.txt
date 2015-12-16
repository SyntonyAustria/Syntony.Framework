contains solution wide files like Assemblyinfo, CustomDictionary.xml,

To make a symbolic link to that directory inside a solution directory execute the following command from an elevated command prompt with administrator rights (Run as administrator):
MKLINK /J "new absolute path link" "this absolute directory" ... don't forget the quotation marks ("...") or have a look at http://www.sevenforums.com/tutorials/278262-mklink-create-use-links-windows.html

use LINK SHELL EXTENSION http://schinagl.priv.at/nt/hardlinkshellext/hardlinkshellext.html#referencecount     Junction
