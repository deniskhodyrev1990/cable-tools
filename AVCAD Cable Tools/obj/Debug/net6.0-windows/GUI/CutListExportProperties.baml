   M S B A M L   `   `   `  ????L  HAVCAD Cable Tools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AVCAD.GUI	AVCAD.GUI  5   	   '    !AVCAD.GUI.CutListExportProperties   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AVCAD.GUI     5   	     ? Title$   Cut List Export Properties??5   	    ? SizeToContent$ WidthAndHeight=?5	   	    ? WindowStartupLocation$ CenterScreen=?5
   	    ? 
ResizeMode$ NoResize=?5   	   .??5      ? .+?5   
   ??  ?? Orientation$ Vertical=?6   $??10q?6,   .+?5      ?? $%??Select which cable reels to use??5      $??16(?5      $??Center=?5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ CableReelsDataGrid??5      $??10q?5      $	??500??5      $	??400??5         AutoGenerateColumns$ False??5         CanUserAddRows$ False??5         CanUserDeleteRows$ False??5      ??5      ?? *FilteredCollection+	   Columns	 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 0.1* 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   ?? *
IsSelected+ ?? Mode$ TwoWay=?   Header 5      ?? 5       -   5         ??Name$ SelectAllCheckBox??5!   %   ??5"   %   ??  ?? Path$4 .DataContext.SelectDeselectAllCableReelsCommand? ?? ElementName$ CableReelsDataGrid????5#   %   ?? $ SelectAllCheckBox??$ 	IsChecked?5%      0  *System.Windows.Controls.DataGridTextColumn  5&      $

 0.4* 6C      
IsReadOnly$
 True??6P    6)   ?? *Name+ 5'      ?? 5(      $ Vertical=?6)   .+?5)   "   ?? $??Center=?6(   $??Center=?6C   $??Center=?6g   $
??Name??6?   ?? 5*   "   -   5         ??Name$ NameTextBox??5*   *   $	??100??6@   ??6O   ?? *DataContext.NameFilter+ ?? RelativeSource ??  ?? AncestorType"   ?? UpdateSourceTrigger$ PropertyChanged=?5+      5-        5.      $

 0.3* 6G   $
 True??6T    6)   ?? *	CableType+ 5/      ?? 50      $ Vertical=?6)   .+?51   "   ?? $??Center=?6(   $??Center=?6C   $??Center=?6g   $??
Cable Type??6?   ?? 52   "   -   5        $ CableTypeTextBox??52   *   $	??100??6?   ??6D   ?? *DataContext.TypeFilter+ ?? "  $ PropertyChanged=?6?   53      55        56      $ Length??6D   $

 0.2* 6T   $
 True??6a    6)   ?? *Length+6a   58      ?? 5=      $ 
Horizontal=?6   $??Center=?66   .+?5>      ?? -   5         ??Name$ 	SubmitBtn??5?      $??Submit??5@      $??10q?5A      5C      ?? 5D      -   5        $ 	CancelBtn??5E      $??Cancel??5F      $??10q?5G      $??Right=?5H       ? Cursor$
 Hand??6I   5I      5J      5K      5M      5N      