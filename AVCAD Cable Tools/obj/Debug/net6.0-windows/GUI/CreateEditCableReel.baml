   M S B A M L   `   `   `  ????L  HAVCAD Cable Tools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AVCAD.GUI	AVCAD.GUI  5   	   #    AVCAD.GUI.CreateEditCableReel   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AVCAD.GUI     5   	     ? SizeToContent$  WidthAndHeight=?5   	    ? 
ResizeMode$ NoResize=?5	   	    ? WindowStartupLocation$ CenterScreen=?5
   	   $	??250??5   	   .??5      ? .+?5   
   ??  ?? Orientation$ Vertical=?6   .+?5      ?? $??
10,10,10,2q?6   .??6(   Name6.   ?? 5      $??
10,2,10,10q?5      ??5      ?? *Name+5      ?? 5      $??
10,10,10,2q?6   .??6(   Length60   ?? 5      $??
10,2,10,10q?5      ??5      ?? *Length+5      ?? 5      $??
10,10,10,2q?6   .??6(   
Cable Type64   ?? 5      -   5         ??Name$ CableTypesComboBox??5      $??
10,2,10,10q?5       ?? IsTextSearchEnabled$
 True??5        ?? IsTextSearchCaseSensitive$ False??5       ?? SelectedValue 5      ?? *	CableType+5      ?? 5       $ 
Horizontal=?6   $??Center=?62   .+?5!      ?? -   5         ??Name$ 	SubmitBtn??5"      $??Submit??5#      $??10q?5$      5&      ?? 5'      -   5        $ 	CancelBtn??5(      $??Cancel??5)      $??10q?5*      $??Right=?5+      	 ? Cursor$
	 Hand??6I   5,      5-      5/      50      51      