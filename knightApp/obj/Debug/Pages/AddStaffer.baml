   M S B A M L   `   `   `  ����D  @knightApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:knightApp.PagesknightApp.Pages  5           knightApp.Pages.AddStaffer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:knightApp.Pages     5        N� Title$  
AddStaffer��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��40 �6   6*   �� 5      6   �� 5      $��40 �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   � $��2��6      headerBackground#��[  5      6;   �� 5   
   $��2��6     
headerText#��[ 5      6:   �� 5   
   $��2��6   $��0��5      $��Center=�5      $��Center=�5       .+�5!      ��  �� Orientation$ 
Horizontal=�6   $��Right=�5"        AttributesCurrentEntity#��[ 5#      .+�5$      �� $��Фамилия: ��6   6/   �� 5%      -   5        $��TBoxLastname��5%        TBoxDataCurrentEntity#��[ 5&      6K   5'      �� 5)      $ 
Horizontal=�6   $��Right=�5*      #��[ 5+      .+�5,      �� $��Имя: ��6   6+   �� 5-      -   5        $��TBoxName��5-      #��[ 5.      6K   5/      �� 51      $ 
Horizontal=�6   $��Right=�52      #��[ 53      .+�54      �� $��Отчество: ��6   60   �� 55      -   5        $��TBoxPatronymic��55      #��[ 56      6K   57      �� 59      $ 
Horizontal=�6   $��Right=�5:      #��[ 5;      .+�5<      �� $#��Номер телефона: ��6   66   �� 5=      -   5        $��TBoxPhoneNumber��5=      #��[ 5>      6K   5?      �� 5A      $ 
Horizontal=�6   $��Right=�5B      #��[ 5C      .+�5D      �� $��Должность: ��6   61   �� 5E      -   5        $��ComboBoxPosition��5E        ComboBoxCurrententity#���  5F        CBoxDataCurrentEntity#��[ 5G      6K   5H      5I      �� 5K   
   $��Center=�6   $��Center=�5L      $��2��5M      $��1��5N      .+�5O      �� $
��Left=�6   $	��Top=�5P      .+�5Q      ��   PreviewImage#��[ 6   
���� ��$��2q�5S      ._�5T      �� -   5        $��ImageStaffer��5T      62   5U      5V      �� 5X      .+�5Y      �� -   5        $[��UC:\Users\Кристина\Desktop\CourseWork\knightApp\knightApp\Images\ButtonAdd.png��5Y        ButtonsImage#��[ 5[      $
��Left=�5\      $��97 0 0 0q�5]      5^      5_      �� 5a   
   -   5        $��ButtonAddSporsman��5d      $��4��5a      $��2��5b      $��Сохранить��5c        ButtonSections#��[ 5e       � 	Resources 5g       �� 
TargetType �� Property �� Value��%d   '��       �� 5h      " ��6   .�5i      ��  �@��CornerRadius$ 20��65   6B   5j      5k      5l      �� 5n   
   -	   5        $��/Images/left-arrow.png��5n       	 	ArrowLeft#��[	 5o      $��0��5p      $��0��5q      5r      5s      5t      