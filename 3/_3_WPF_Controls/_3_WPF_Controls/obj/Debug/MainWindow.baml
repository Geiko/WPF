   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections  5   	   J F_3_WPF_Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_3_WPF_Controls_3_WPF_Controls 5   	       _3_WPF_Controls.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	   /localclr-namespace:_3_WPF_Controls     5   	     � Title$
  Cats��5   	   $	��350��6   $	��525��6#   .��5      � -   5         �Name$
 grid��5      .+�5
   
   o� .@�5      m� $
��File��6    m� Icon 5      �� 5      $��
image1.png��6   62   .@�5      m� $��Save As��6    5      �� 5      $��
image3.png��6    66   .@�5      m� -   5        $	��XML��5       5      �� 5      $��kitty_1.png��6$   6;   5      m� 5      -   5        $	��TXT��5       5      �� 5      $��git.png��6$   67   5   +   5      5      m� 5      -   5        $��
Input Name��5       5      �� 5       $��
image2.png��6   62   5"      5#      �� 5&   
   -   5         ��Name$ slider1��5&       � Maximum$ 20Q�6"    � Minimum$ 0Q�6/    � Value$ 0Q�6;   $��327,21,19,266q�6E    �� IsSnapToTickEnabled . 
���  �� �� TickPlacement$ TopLeft=�5'   "   	 �� AutoToolTipPlacement$	 BottomRight=�6:   
 �� TickFrequency$
 1Q�6]   5(      �� 5)   
   -   5        $ slider2��5)      $ 20Q�6"   $ 0Q�6/   $ 20Q�6;   $��327,88,19,199q�6F    . 
���  ��$ TopLeft=�5*   "   $	 BottomRight=�6:   $
 1Q�6]   5+      �� 5,   
   $
��Left=�6   $��
250,21,0,0q�6/   $
��Wrap=�6C   $��Age From : ��5-      $	��Top=�6'   �� 5.   
   $
��Left=�6   $��
290,88,0,0q�6/   $
��Wrap=�6C   $��To : ��5/      $	��Top=�6!   �� 52   
   -   5         ��Name$ combobox��52      $��327,166,19,121q�6%    �� 
IsEditable .  �� Text$ Breed��6O   53      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ datagrid��56         AutoGenerateColumns .     RowBackground
 � ���   AlternatingRowBackground
 �2͚�   	RowHeight$ 25Q�57   :      GridLinesVisibility$
 None=�6J      cats#���   58      $��21,88,264,20q�6D    � 	Resources 5:      "   System.Collections.ArrayList  _3_WPF_Controls.Cat   Name
   Age   Breed��%z  &	          5;        5<      $ Snuker��6    $ 1��6.   $ British=�66   6H     5=      $ Vasya��6    $ 2��6-   $
 Pers=�65   6D     5>      $ Masya��6    $ 3��6-   $ Sfinks=�65   6F     5?      $ Begemot��6    $ 4��6/   $ British=�67   6I     5@      $  ��6    $ 5��6(   $ Unknown=�60   6B     5A      $ Lusya��6    $ 6��6-   $ Sfinks=�65   6F     5B      $ Murka��6    $ 7��6-   $ Unknown=�65   6G     5C      $ Hippo��6    $ 8��6-   $
 Pers=�65   6D     5D      $ Lucky��6    $ 9��6-   $ Sfinks=�65   6F   5E      5F         Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$ Breed��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$ Breed�6S     5J      $
 Name��6%   $ 70 6Q    63   �� $
 Name�6Q     5K      $	 Age��6%   $ 30 6O    62   �� $	 Age�6O    � ContextMenu 5N      �� 5O      .@�5P      m� -	   5        $��Delete��5P      6S   5Q      5S      �� 5V   
   -
   5        $��327,234,41,20q�5V      
���2͚� J� Opacity$	 0.9Q�5W   *   .��5X      ��  �� Orientation$ 
Horizontal=�6   .+�5Y      �� $��
image8.png��6   $��53��6,   $��60��68   �� 5Z      $
��Wrap=�6   $��72��60    Download all Cats to the Table6[   5[      5\      5_      5`      