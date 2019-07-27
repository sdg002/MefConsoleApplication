# Overview
This is the code which accompanies my CodeProject article **Using Managed Extensibility Framework to Build a Modular Console Application**. 
In this article I have demonstrated how we can break down a Console Application into Tasks, where each Task is implemented by a dedicated C# class and these classes are given short names. The EXE uses Managed Extensibility Framework to load these classes at runtime

![Console app tasks](https://www.codeproject.com/KB/dotnet/5162604/TestConsoleExe.PNG)



# Link to article
https://www.codeproject.com/Articles/5162604/Using-Managed-Extensibility-Framework-to-build-a-m

# MefConsoleApplication.sln
This solution has two projects

## 1.MefSkeletal.csproj
Demonstrates the core ideas of Managed Extensibility Framework. 

## 2.MefSkeletalWithHelp.csproj
Goes a step forward by implementing a simple Help System. The Help information is handled by a C# class loaded through MEF.


# MefConsoleApplicationWithPluginsFolder.sln
In this solution I have demonstrated how the various taks are implemented in their respective class libraries. The class libraries are copied over to a Plugins folder and the EXE uses MEF to discover the handler components at runtime.  The only binding information between the EXE and the plugins are 

```
EXE----
        |
        |
       Bin--
            |
            |
            Release
                |
                |
                netcoreapp2.1
                    |
                    |
                   Plugins
                        |
                        |
                        Task 1
                        |
                        |   (all assemblies,PDB and other files from the Bin of Task1)
                        |
                        |
                        Task 2

                            (all assemblies,PDB and other files from the Bin of Task2)

```
