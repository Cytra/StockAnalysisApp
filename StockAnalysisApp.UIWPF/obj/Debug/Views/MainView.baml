   M S B A M L   `   `   `  ����Q  MStockAnalysisApp.UIWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StockAnalysisApp.UIWPF.ViewsStockAnalysisApp.UIWPF.Views  5	   	   +    %StockAnalysisApp.UIWPF.Views.MainView   5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  9Window,http://metro.mahapps.com/winfx/xaml/controls  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:StockAnalysisApp.UIWPF.Views     5	   	   -   5          � Title$  MainView��5   	   $	��800��6   $	��850��6'    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��10 �6   6*   �� 5      $��30 �6   6*   �� 5      $��10 �6   6*   �� 5      $��30 �6   6*   �� 5       $��10 �6   6*   �� 5!      $��30 �6   6*   �� 5"      $��10 �6   6*   �� 5#      $��30 �6   6*   �� 5$      $��10 �6   6*   �� 5%      $��* �6   6)   �� 5&      $��10 �6   6*   .+�5*   
   �� $��1��6   $��1��5+      .��6    Stock Ticker6.   �� 5-   
   $��1��6   $��3��5.      ��5/      �� *StockTicker+ �� UpdateSourceTrigger$ PropertyChanged=�6V   �� 51   
   $��1��6   $��5��52      $��3��53      $��Center=�54      .��55      	PREPARE6   �� 56   
   $��3��6   $��5��6   $��3��6.   ��57      �� *	Prepare+.��6-   
PREPRARE67   �� 59   
   $��5��6   $��5��5:      $��3��5;      $��Center=�5<      .��5=      
STRATEGIES6   �� 5>   
   $��7��6   $��5��6   ��6.   �� *GetCompanyKeyMetrics+.��6W   Key Metrics6d   �� 5?   
   $��7��6   $��7��6   ��6.   �� *GetDCF+.��6I   DCF6N   &   System.Windows.Controls.DataGrid  5A   
   $��3��5B      $��1��5C      $��3��5D      $��7��5E         AutoGenerateColumns .  ��5A      �� *SortedStocks+ �� SelectedItem 5G      �� *SelectedStock+y�5H      �� *DataGridVisibility+   Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 3* 6L   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Name+6L     5K      $ Symbol��6%   $	 * 6P   
 65   �� *Symbol+6P     5L      $ Price��6%   $	 * 6N   
 64   �� *Price+6N   5N      )  #MahApps.Metro.Controls.ProgressRing  5P   
   $��9��5Q      $��1��5R      $��7��5S         IsActive 5T      �� *
IsActive+5V      5W      