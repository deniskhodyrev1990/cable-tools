   M S B A M L   `   `   `  ????L  HAVCAD Cable Tools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AVCAD.ViewsAVCAD.Views  5      3clr-namespace:AVCAD.ConvertersAVCAD.Converters  5      3clr-namespace:AVCAD.ViewModelsAVCAD.ViewModels  5          AVCAD.Views.CableListView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:AVCAD.Views     5      5
convertersclr-namespace:AVCAD.Converters     5      5
viewmodelsclr-namespace:AVCAD.ViewModels     5      -   5          N?Name$  CableListPage??5       N? Title$ CableListPage??5       ? 	Resources 5      0   *AVCAD.Converters.MulticoreMembersConverter   MulticoreMembersConverter??%   &	          5   
   6S   5      .??5      ]? .+?5   
   ? -   5         ?Name$ MainWindowGrid??5       ? ColumnDefinitions 5      ?? 5      $
??1.0* ?6#   62    ? RowDefinitions 5      ?? 5      $
??0.1* ?6    60   ?? 5      $
??0.9* ?6    60   .+?5      ?? $??Center=?5      $
??Left=?5       ?? Orientation$ 
Horizontal=?5      $??0??5      $??0??5      .+?5      ?? $??
Load Excel??5       $??10q?5!      $
??Auto??5"      $
??Left=?5#       ? Cursor$
 Hand??5$   >   ??6   ?? *LoadExcelFileCommand+6>   ?? 5%      $??
Save Excel??5&      $??10q?5'      $
??Auto??5(      $
??Left=?5)      $
 Hand??5*   >   ??6   ?? *SaveExcelFileCommand+6>   ?? 5+      $??Make Multicore??5,      $??10q?5-      $
??Auto??5.      $
??Left=?5/      ??50      ?? *MakeMulticoreCommand+??51      ??  ?? ElementName$ CablesDataGrid??	 ?? Path$	 SelectedItems??? 52      $??Create Cutlist??53      $??10q?54      $
??Auto??55      $
??Left=?56      ??57      ?? *CreateCutListCommand+?? 58      $??Center=?59      $??16(?5:      ??5;      ?? *
Filename+5<      &   System.Windows.Controls.DataGrid  5=      -   5        
  Name$
 CablesDataGrid??5@      $??0??5>      $??1??5?      $??10q?5B         AutoGenerateColumns$ False??5C         CanUserAddRows$ False??5D         CanUserDeleteRows$ False??5E      $	??500??5F      ??5A      ?? *Cables+ ?? Mode$ OneWay=? 5H      )  #System.Windows.Controls.DataGridRow ?? 
TargetType ?? Property ?? Value   AVCAD.Views.BindingProxy  SysnameOutVisibleProxy   Data  ConnectorOutVisibleProxy  PortOutVisibleProxy  ModelOutVisibleProxy  LocationOutVisibleProxy  SysnameInVisibleProxy  ConnectorInVisibleProxy  PortInVisibleProxy 	 ModelInVisibleProxy 
 LocationInVisibleProxy??%?  '        &	 b     &	 ?     &	 ?     &	 ?     &	 '    &	 Z    &	 ?    &	 ?    &		 ?    &	
     ?? 5I      "  6   .?5J      ??  ?@ 
IsSelected 67   ?? *
IsSelected+5K        5L       6H   ?? *SysnameOutVisible+  5M       6J   ?? *ConnectorOutVisible+  5N       6E   ?? *PortOutVisible+  5O       6F   ?? *ModelOutVisible+  5P       6I   ?? *LocationOutVisible+  5Q       6G   ?? *SysnameInVisible+  5R       6I   ?? *ConnectorInVisible+  5S       6D   ?? *PortInVisible+  5T       6E   ?? *ModelInVisible+  5U       6H   ?? *LocationInVisible+5V         Columns 5W      0  *System.Windows.Controls.DataGridTextColumn  5X      ,  &System.Windows.Controls.DataGridColumn   Header$ Cable Number??6)      
IsReadOnly$
 True??6_      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   ?? *CableNumber+6?     5Y      $ Sysname Out??6)   $
 True??6]   $
 Auto 6o    6>   ?? *
SysnameOut+   
Visibility 5Z   )   ?? *Data+   BooleanToVisibilityConverter ?? 	Converter# [  ?? Source# [   5[      $ Connector Out??6)   $
 True??6a   $
 Auto 6s    6@   ?? *ConnectorOut+ 5\   )   ?? *Data+# [ # [   5]      $ Port Out??6)   $
 True??6W   $
 Auto 6i    6;   ?? *	PortOut+ 5^   )   ?? *Data+# [ # [   5_      $ 	Model Out??6)   $
 True??6Y   $
 Auto 6k    6<   ?? *
ModelOut+ 5`   )   ?? *Data+# [ # [   5a      $ Location Out??6)   $
 True??6_   $
 Auto 6q    6?   ?? *LocationOut+ 5b   )   ?? *Data+# [ # [   5c      $ 
Sysname In??6)   $
 True??6[   $
 Auto 6m    6=   ?? *	SysnameIn+ 5d   )   ?? *Data+# [ # [   5e      $ Connector In??6)   $
 True??6_   $
 Auto 6q    6?   ?? *ConnectorIn+ 5f   )   ?? *Data+# [ # [   5g      $ Port In??6)   $
 True??6U   $
 Auto 6g    6:   ?? *PortIn+ 5h   )   ?? *Data+# [ # [   5i      $ Model In??6)   $
 True??6W   $
 Auto 6i    6;   ?? *	ModelIn+ 5j   )   ?? *Data+# [ # [	   5k      $ Location In??6)   $
 True??6]   $
 Auto 6o    6>   ?? *
LocationIn+ 5l   )   ?? *Data+# [ # [
   5m      $ 
Cable Type??6)   $
 True??6[   $
 Auto 6m    6=   ?? *	CableType+6m     5n      $ Cable Length??6)   $
 Auto 6_    6?   ?? *CableLength+   ElementStyle 5o      ?? 5p      " ??6$   .?5q   "   ??  ? ??$ Center=?6H   5r      5t        5u      $ Extra(%)??6)   $
 Auto 6[    6;   ?? *ExtraLength+ 5v      ?? 5w      " ??6$   .?5x   "   ??  ? ??$ Center=?6H   5y      5{        5|      $ Multicore Members??6)   $
 Auto 6D   $
 True??6?    6Q   ?? *MulticoreMembers+# [  6?    ? ContextMenu 5~      ?? 5      .@?5?      m? $??Select Cable Types??5?       m? Command 5?      ?? *SelectCableTypeCommand+ m? CommandParameter 5?      ?? *PlacementTarget.SelectedItems+ ?? RelativeSource ?? *FindAncestor+  ?? AncestorType"  ??5?       m? 5?      $??Make Multicore??5?       5?      ?? *MakeMulticoreCommand+ 5?      ?? *PlacementTarget.SelectedItems+ ?? *FindAncestor+"  ??5?       m? 5?      $??Exclude from multicore??5?       5?      ?? *ExcludeFromMulticoreCommand+ 5?      ?? *PlacementTarget.SelectedItems+ ?? *FindAncestor+"  ??5?       5?      5?      5?      5?      5?      