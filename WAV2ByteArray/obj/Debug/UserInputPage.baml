   M S B A M L   `   `   `  ����H  DWAV2ByteArray, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WAV2ByteArrayWAV2ByteArray  5   	   !    WAV2ByteArray.UserInputPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WAV2ByteArray     5   	     N� Title$  	InputPage��5   	   $	��350��5	   	   $	��500��5
   	   .��5      � -   5        $��UserInputGrid��5       � ColumnDefinitions 5   
   �� 5      $	��400 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   $��2��6.   $��30��6B   $	��500��6N   ���#4E87D4$	��Top=�6o   $
��Left=�6�   ._�5      �� $��Center=�6   $��Center=�6/   
�������$
��Auto��6_   $��
95,4,168,0q�6m   .��6�   ,*Locate .WAV files you wish to be converted6�   5      �� 5   
   -   5        $��	FilesList��5      $��0��6#   $��0��63   $��0,35,0,0q�6@   .@�5      �� -   5        $��AddressBar_1��5      
�������$��2q�6B   $
��Auto��6V   $��20��6c   .��6o   ...6t   5      �� 5   
   -   5        $��FindAddressButton_1��5      $��0��6,   $��1��69   $��5,37,0,0q�6I   $
��Auto��6[   $��20��6h   $	��Top=�6t   $
��Left=�6�   .��6�   ...6�   �� 5    
   -   5        $��NewFileButton��5       $��1��6&   $��10,6,0,0q�63   $
��Auto��6E   $��18��6R   $	��Top=�6^   $
��Left=�6v   .��6�   
New Item6�   �� 5!   
   -   5        $��RemoveFileButton��5!      $��1��6)   $��79,6,0,0q�66   $
��Auto��6H   $��18��6U   $	��Top=�6a   $
��Left=�6y   .��6�   Remove Last Item6�   �� 5"   
   -   5        $��ConvertButton��5"      $��1��6&   $
��Auto��66   $��30��6C   $	��Top=�6O   .��6|   	Convert6�   5#      5$      