This test configuration/scripts are for IIS installation.


0. Prerequisites
Microsoft Windows, NET Core Framework 2.0+, Microsoft IIS (with URL rewrite) + ASP.NET Core, MySQL database.


1. Local test website
Configure local test IIS website to be hosted on www.ff.com:8000 (main) and m.ff.com:8000 (mobile)
Create new application pool (say "NET Core 2.0") with "No managed code" CLR version.
Assign this application pool to newly created IIS website.
Set Read/Execute permissions for .\Bula\Fetcher\Web.Core folder to virtual user "IIS AppPool\NET Core 2.0"
Set Modify permissions for .\local\cache folder to virtual user "IIS AppPool\NET Core 2.0"

Add following hosts into C:\Windows\System32\drivers\etc\hosts
127.0.0.1 ff.com
127.0.0.1 www.ff.com
127.0.0.1 m.ff.com


2. Wget application
Download and copy wget (for Windows) and its dependencies into .\local\bin folder


3. WinMerge application
Download and install WinMerge for Windows into C:\Program Files\WinMerge folder


4. Configure
4.1. Set your test (local) site info in 0_runme.bat (default is *.ff.com:8000)
4.2. Set your database info/credentials and location of mysql.exe in 1_create.bat (default is 'dbusnews' with the same user and password)
4.3. Set security code in 3_fetch.bat exactly the same as in .\Bula\Fetcher\Config.cs (default is '1234')
4.4. Download MySQL Connector/NET (mysql.data.dll) and put it into .\Bula\Model folder


5. Rebuild solution


6. Launch tests
To run all tests you should execute 0_runme.bat. There are 8 test sets:
6.1 create and load database (using sql-files from 'input' folder)
6.2 fetch items from source RSS-feeds (using xml-files from 'input' folder)
6.3 check styles.css files
6.4 check pages for browsing items & sources
6.5 check actions (redirecting to external items/sources)
6.6 check pages for viewing items
6.7 check RSS-feeds generation logic
6.8 check methods calling

Each test set contains positive and negative sub-sets.

Sets #4 (pages) and #6 (view) are also have 3 sub-sets: for direct, full & fine links.

Sets #4 & #6 are executed twice - for ordinary website and mobile version.

Test results are written in 'output' folder and compared (using WinMerge) to reference results, located in 'origin' folder.


