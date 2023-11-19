rm CustomTuneToon.zip
cd bin/Debug/net7.0-windows
zip -r CustomTuneToon.zip Tunetoon.exe Tunetoon.dll Tunetoon.deps.json Tunetoon.runtimeconfig.json ICSharpCode.SharpZipLib.dll Newtonsoft.Json.dll
mv CustomTuneToon.zip ../../../