   M S B A M L   `   `   `  ����A  =ALMSPL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ALMSPLALMSPL  5   	       ALMSPL.AddEmployee   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ALMSPL     5   	     � Title$  AddEmployee��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   �� $
��Name��6   $
��Left=�6   $��	10,57,0,0q�6:   $	��Top=�6M   �� 5   
   -   5        $��txtName��5   �   $
��Left=�6   $��23��6-   $��
125,57,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $	��120��6y   6�   �� 5   
   $��Email��6   $
��Left=�6    $��
10,103,0,0q�6;   $	��Top=�6O   �� 5   
   -   5         ��Name$ txtEmail��5   �   $
��Left=�6   $��23��6-   $��125,103,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��120��6z   6�   �� 5   
   $��Phone��6   $
��Left=�6    $��
10,152,0,0q�6;   $	��Top=�6O   �� 5   
   -   5        $ txtPhone��5   �   $
��Left=�6   $��23��6-   $��125,155,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��120��6z   6�   �� 5   
   $��Employee Role��6   $
��Left=�6(   $��
10,195,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $��empRole��5   g   $
��Left=�6   $��125,195,0,0q�6.   $	��Top=�6C   $	��120��6[   .@�5      �� $��Select��6   �� 5      $��A5��6   �� 5      $��A4��6   �� 5      $��A3��6   �� 5      $��A2��6   5      �� 5   
   $��Password��6   $
��Left=�6#   $��
10,230,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ txtPassword��5   �   $
��Left=�6   $��23��6-   $��125,230,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��120��6z   6�   �� 5   
   $��
Manager Id��6   $
��Left=�6%   $��
10,275,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ txtMId��5   �   $
��Left=�6   $��23��6-   $��125,275,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��120��6z   6�   �� 5   
   $��
Project Id��6   $
��Left=�6%   $��
10,310,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ txtPId��5   �   $
��Left=�6   $��23��6-   $��125,310,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��120��6z   6�   �� 5    
   -   5        $��Save Details��5       $
��Left=�6(   $��
15,380,0,0q�6C   $	��Top=�6W   $��75��6o   6z   �� 5!   
   $��Employee Details��6   $
��Left=�6+   $��
305,10,0,0q�6F   $	��Top=�6Z   
���  ��$��25(�6�   &   System.Windows.Controls.DataGrid  5"   
   -	   5        $��dgEmployees��5"   s   $
��Left=�6   $	��204��6.   $��
351,58,0,0q�6;   $	��Top=�6O   $	��431��6g   ��6�   �� �� 5#   
   $
��Id :��6   $
��Left=�6   $��400,320,0,0q�6:   $	��Top=�6O   �� 5$   
   -
   5        $ txtId��5$   �   $
��Left=�6   $��23��6-   $��440,320,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��120��6z   6�   �� 5%   
   -   5        $��Search Employee��5%      $
��Left=�6+   $��580,320,0,0q�6F   $	��Top=�6[   $	��107��6s   6   �� 5&   
   -   5        $��Update Employee��5&      $
��Left=�6+   $��450,280,0,0q�6F   $	��Top=�6[   $	��106��6s   6   �� 5'   
   -   5        $��Delete Employee��5'      $
��Left=�6+   $��600,280,0,0q�6F   $	��Top=�6[   $��96��6s   6~   �� 5(   
   $��Status��6   $
��Left=�6!   $��
10,349,0,0q�6<   $	��Top=�6P   �� 5)   
   -   5        $ 	txtStatus��5)   �   $
��Left=�6   $��23��6-   $��125,349,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��120��6z   6�   5,      5-      