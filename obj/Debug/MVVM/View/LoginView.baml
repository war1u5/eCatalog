   M S B A M L   `   `   `  ????C  ?eCatalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:eCatalog.MVVM.VieweCatalog.MVVM.View  5      "    eCatalog.MVVM.View.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:eCatalog.MVVM.View     5      .??5	      ?   ? ColumnDefinitions  5
   
   ?? 5      ?? 5      ?? 5      .+?5   
   ?? $??1??6   
?????? .+?5      ?? $??..\..\Images\nice.png??6   ?? 5      $??
Utilizator??6   
???   ?$??20(?5      $??	0 30 0 0 q?5      ?? 5      -   5         ??Name$
 user??5       ? ToolTip$ Introduceti user??5      $??21(?5      
???   ? ?? 
CaretBrush ?#2d8659???#B3E5CC$??0 0 0 1q?5      $??30??5      $??Center=?5       $??0 5 0 0q?5!      $??40 0 0 0q?5"      .??6B   ??5#      ?? 5$       ?? ImageSource$ ..\..\Images\user.PNG??6!    j? Stretch$
 None=?5%   !    j? 
AlignmentX$
 Left=?5&   !   .??5'   &   5(      ?? 5*      $??Parola??6   
???   ?$??20(?5,      $??0 35 0 0q?5-      G? 5/      -   5         G?Name$
 pass??5/      $ Introduceti parola??50      $??21(?51      
???   ? G? 
CaretBrush ?#2d8659???#B3E5CC$??0 0 0 1q?55      $??30??56      $??Center=?57      $??0 5 0 0q?58      $??40 0 0 0q?59      ??5:      ?? 5;      $ ..\..\Images\pass.PNG??6!   $
 None=?5<   !   $
 Left=?5=   !   5?      ?? 5A      -   5        	 ??Name$	 WarningLabel??5A      $??20(?6.   
???  ??$??0 30 0 0q?6M   $??Center=?6_   
?????? 6|   	? 5C      -   5        
 	?Name$
 AutentifBtn??5D      $??Autentificare??5C      $??50??5E      
???   ?$??14(?5G      $	??200??5H      $??	0 100 0 0q?5I         LoginButtonTheme#??[  5J      5K      5M      5O      5P      