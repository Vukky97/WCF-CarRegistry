   M S B A M L   `   `   `  ����G  CWCFWPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WCFWPFClientWCFWPFClient  5   	       WCFWPFClient.AdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WCFWPFClient     5   	     � Title$  AdminWindow��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $
��Left=�6%   $	��399��6@   $��	10,10,0,0q�6M   $	��Top=�6`   $	��224��6x    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value:  4System.Windows.Controls.Primitives.DataGridRowHeader��%�   '        7 '  s     7 �� 5      8   "  6Q   .�5      ��  � ��
 � E��63   �� 5       � ��$ 10q�60   5      �� 5      8   "  6N   .�5      ��  � ��
 � E��63   5      5      5      �� 5   
   -   5         ��Name$ BTNBack��5      
�������$��Close��69   $
��Left=�6I   $��632,359,0,0q�6d   $��50��6y   $	��150��6�   $	��Top=�6�   $��30(�6�   $��Italic$�6�   $
��Bold"�6�   6�   �� 5   
   $��Operation with userID: ��6   $��20(�62   $��Italic$�6@   $
��Bold"�6S   $
��Left=�6e   $��
401,38,0,0q�6�   $	��Top=�6�   �� 5   
   $��Name : ��6   $��20(�6"   $��Italic$�60   $
��Bold"�6C   $
��Left=�6U   $��350,166,0,0q�6p   $	��Top=�6�    J� RenderTransformOrigin$ 
0.635,0.47&�6�   �� 5   
   $��Password : ��6   $��20(�6&   $��Italic$�64   $
��Bold"�6G   $
��Left=�6Y   $��335,203,0,0q�6t   $	��Top=�6�   �� 5   
   $�� New Password : ��6   $��20(�6+   $��Italic$�69   $
��Bold"�6L   $
��Left=�6^   $��302,240,0,0q�6y   $	��Top=�6�   �� 5   
   -   5        	 ��Name$	 TBOperationID��5      $
��Left=�6)   $��28��6D   $��
476,93,0,0q�6P   
 �� TextWrapping$

 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   $��18(�6�   �� 5   
   -   5        $	 TBName��5      $
��Left=�6"   $��28��6=   $��476,175,0,0q�6I   $

 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   $��18(�6�   �� 5   
   -   5        $	 
TBPassword��5      $
��Left=�6&   $��28��6A   $��476,212,0,0q�6M   $

 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   $��18(�6�   �� 5   
   -   5        $	 TBNewPassword��5      $
��Left=�6)   $��28��6D   $��476,249,0,0q�6P   $

 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   $��18(�6�   �� 5   
   -   5        $ BTNGetID��5      $��Italic$�6#   $
��Bold"�66   
��� E��$��18(�6_   $��Get User��6m   $
��Left=�6�   $��
619,93,0,0q�6�   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ 	BTNDelete��5      $��Italic$�6$   $
��Bold"�67   
��� E��$��18(�6`   $��Delete User��6n   $
��Left=�6�   $��619,126,0,0q�6�   $	��Top=�6�   $	��120��6�   6�   �� 5    
   -	   5        $ BTNChangePassword��5       $��Italic$�6,   $
��Bold"�6?   
��� E��$��18(�6h   $��Change Password��6v   $
��Left=�6�   $��381,300,0,0q�6�   $	��Top=�6�   $	��189��6�   $��33��6  5"      5#      