   M S B A M L   `   `   `  ????C  ?eCatalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:eCatalogeCatalog  5   	   A%clr-namespace:eCatalog.MVVM.ViewModeleCatalog.MVVM.ViewModel  5   	       eCatalog.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:eCatalog     5   	   ;	viewModel%clr-namespace:eCatalog.MVVM.ViewModel     5   	   $	??800??5	   	   $
??1200??6     ? WindowStyle$
  None=?5
   	    ? 
ResizeMode$ CanMinimize=?5   	   
??????  ? AllowsTransparency .  ? WindowStartupLocation$ CenterScreen=?5   	    ? DataContext 5      +  %eCatalog.MVVM.ViewModel.MainViewModel  5   
   .??5      ?? ???#d7eee2 ?? CornerRadius$ 15??5      ._?5   
   ?  ? ColumnDefinitions 5      ?? 5       $	??200 ?6#   ?? 5!       ? RowDefinitions 5%      ?? 5'      $??75 ?6    ?? 5(      ?? 5)      $??50 ?6    .+?5-      ?? -   5         ??Name$ MinimizeBtn??5-      	 ? ToolTip$	 Minimize??5.      $??0q?5/      $??-??50      
???   ?
 ? Cursor$

 Hand??52      $??1??53      $	??Top=?54      $??33??55   +   $??
930,7,35,0q?67   $??24(?6K      MinimizeButtonTheme#??[  56      58      ?? 5:      -   5        $ ExitBtn1??5:      $
	 Exit??5;      $??0q?5<      $??x??5=      
???   ?$

 Hand??5?      $??1??5@      $	??Top=?5A      $??33??5B   ,   $??	960,7,5,0q?68   $??14(?6K     ExitButtonTheme#??[ 5C      5E      ?? 5G      ???#79D2A6$??0??6*   $??0??6:   $ 15??6G   $??90??6Y   ._?5H      ?? $??Images/nice.png??6   $??Center=?5I      $
??Left=?5J      $??	20 0 0 10q?5K      $
??Fill=?5L      $	??150??5M      $??75??5N      5O      ?? 5Q      $??1??6   ???#79D2A6.+?5S      	? -   5         	?Name$ HomeBtn??5T      $??Autentificare??5S      $??50??5U      
???   ?$??14(?5W        MenuButtonTheme#??[ 5X       d? 	IsChecked$
 TrueY?5Y      ??5Z      ?? *LoginViewCommand+	? 5\      -   5        $ 	DespreBtn??5]      $??Despre eCatalog??5\      $??50??5^      
???   ?$??14(?5`      #??[ 5a      ??5b      ?? *DespreViewCommand+	? 5d      -   5        $ 
ContactBtn??5e      $??Contact??5d      $??50??5f      
???   ?$??14(?5h      #??[ 5i      ??5j      ?? *ContactViewCommand+5l      ?? 5n      $??1??6   ???#79D2A6$ 15??67   $??	0,651,0,0q?6I   $??2??6\   5p      ?? 5r      $??1??6   $??1??5s      $??10q?5t      ??5u      ?? *CurrentView+5y      5z      5|      