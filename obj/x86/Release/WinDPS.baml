   M S B A M L   `   `   `  ���� E  AFortHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FortHelper
FortHelper      FortHelper.WinDPS   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:FortHelper       � Title$	  DPS��$��893.5��$��1627.667�� � 	Resources    QualityColor �� A �� R �� G �� B  QualityDarkColor   FortHelper.NameList  NameListData��%y   &	        &	 +     &	 V     �� $	 255��$	 200��$	 100��$ 0���� $	 255��$	 160��$ 80��$ 50��  .��� -    �Name$ gridBackground����
�  
� GradientOrigin$ 0.3,0.1&� 
� Center$ 0.3,0.1&�	 
� RadiusX$		 1.2Q�
 
� RadiusY$	
 1.2Q�.���  � Color$ 	#FF233C77�� � Offset$ 1Q�� $ 	#FFABCAD8��$ 0.063Q� � RowDefinitions �� $	��37* ��� $
��500* ��� $	��29* �.+��� -    ��Name$ 
borWeapon1��$��3q�$��
10,10,0,10q�$��1��$
��Left=�$	��454����
� $ 0.7,1&�$ 0.3,0.3&�$	 1Q�$
 1Q�.��� $ White��� # �   $ 1Q�._�� -   $ griBasic��  FortniteBlue#��[ $	��742��$	��Top=� �� $	��24* ��� $	��34* ��� $	��25* ��� $	��34* ��� $
��342* ��� $
��283* �.+�� -   $ griColorHeader��$��3����
� $ 0.5,1.5&�$ 0.5,1&�$
 1Q�.��� $ White��$ 1Q�� # �   �� -    ��Name$ 	imgHeader��$��UniformToFill=� J� Opacity$	 0.5Q�$��Resources/Muster.jpg��$��3��� -   $ griHeaderLine��$
��Left=�$��3��$	��448������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&� �� RelativeTransform V� .~���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q���  �� Angle$ 90Q� �� CenterY$	 0.5Q� �� CenterX$	 0.5Q�T� .��� # �  $ 0.987Q�� # �   $ 0.578Q�&   System.Windows.Controls.DataGrid  -     Name$ 
dagWeapon1��$��4��   	RowHeight$ 30Q�   
IsReadOnly .    AutoGenerateColumns .     HeadersVisibility$
 None=�    GridLinesVisibility$  
Horizontal=�  FortniteLightBlue!   RowBackground#! [ " J� IsHitTestVisible" .  
�������#��[ #   HorizontalGridLinesBrush## [ $��Stretch=�$��Stretch=�$   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$$ * #���  %   Columns% 0  *System.Windows.Controls.DataGridTextColumn  &   
Foreground
& �����'   FontSize$' 18Q�1  +System.Windows.Controls.DataGridBoundColumn(   Binding( �� *	Attribute+  $' 18Q�)   
FontWeight$
) Bold"�( �� *Value+*   ElementStyle* �� .��� + �� Property+ �@��TextAlignment, �� Value$, Right=�-   	CellStyle- �� . �� 
TargetType*  $System.Windows.Controls.DataGridCell".  .��� + � ��$, 0,0,0,3q��� + � ��#, [ �� -   / ��Name$/ 
lblQuality��$��	Legendary��$��7,0,0,0q�$��0q�$��18(�$
��Left=����� 0 �� Color#0 �   �� -	   1 ��Name$1 	cobWeapon��$
��Left=�$��34��$��1��$	��Top=�$	��448��  FortniteComboBox#��[ 
������ $��Comic Sans MS)�$��24(�2 �� SelectedIndex$2 1������ #0 �  ���� ". ��.��� + � ��
, ������� -
   $/ lblWeaponType��$��Ranged | Shotgun��$
��Left=�$��7,0,0,0q�$��2��$	��Top=�$��0q�$��18(��� -   $1 cobPerk1��$
��Left=�$��
58,0,0,243q�$��5��$	��390��#��[ �� -   $1 cobPerk2��$
��Left=�$��58,40,0,203q�$��5��$	��390��#��[ �� -   $1 cobPerk3��$
��Left=�$��58,80,0,163q�$��5��$	��390��#��[ �� -   $1 cobPerk4��$
��Left=�$��58,120,0,123q�$��5��$	��390��#��[ �� -   $1 cobPerk5��$
��Left=�$��58,160,0,83q�$��5��$	��390��#��[    FortHelper.PerkLvlPicker  -   3  Name$3 cobLvL1��   FortHelper.PerkLvlPicker4   ColorChanged$4 cobLvLX_ColorChanged��$��58��$��	0,0,0,243q�$
��Left=�$��5��  -   $3 cobLvL2��$4 cobLvLX_ColorChanged��$��58��$��
0,40,0,203q�$
��Left=�$��5��  -   $3 cobLvL3��$4 cobLvLX_ColorChanged��$��58��$��
0,80,0,163q�$
��Left=�$��5��  -   $3 cobLvL4��$4 cobLvLX_ColorChanged��$��58��$��0,120,0,123q�$
��Left=�$��5��  -   $3 cobLvL5��$4 cobLvLX_ColorChanged��$��58��$��
0,160,0,83q�$
��Left=�$��5��  -   $ dagDPS�� . $��Stretch=�$��
0,205,0,15q�$��5��$��Stretch=�$	��448��#���   .  " .  $��18(�$$ * $ Column=�#! �  $  Vertical=�5   VerticalGridLinesBrush#5 [ #��[ %   ,	  &System.Windows.Controls.DataGridColumn6 	  Header$6 DPS-Fire��
& �  ��( �� *	DPSFire+7 	  HeaderStyle7 �� =
  7System.Windows.Controls.Primitives.DataGridColumnHeader". 
 .��� + � ��
, �  ���� + � ��#, [   $6 
DPS-Nature��
& � ���( �� *	DPSNature+7 �� ". 
 .��� + � ��
, � ����� + � ��#, [   $6 	DPS-Water��
& ����( �� *
DPSWater+7 �� ". 
 .��� + � ��
, ������ + � ��#, [   $6 
DPS-Normal��
& �����( �� *	DPSNormal+7 �� ". 
 .��� + � ��
, ������� + � ��#, [ �� -   8 ��Name$8 	chbShadow��$��Crystal Weapon��$��	317,0,0,1q�$��2��$��16(�$��0, -4, 0, 0q�$��Center=�� -   $ 
griTopLane�����	#FF1C2238$��2��� -   $ 
griBotLane��$��2�����	#FF1C2238$��2��  -   $ dgvInventory�� .  .  $
��Left=�$	��337��$��
469,38,0,0q�$��1��$	��Top=�$
��1141��#! [ 
�������#���  #���  ## [ $ Column=�%   
& �����9 	  Width$	9 110 $6 Weapon��( �� *	sWeapon+* �� ". ��: �� Triggers: P� ; P� Property; � ��< P� Value$< Siegebreaker��. ��� + � ��  FortniteOrange#, [   $	9 200 $6 Perk1��( �� *sPerk1+* �� ". ��.��� + � ��$
, Wrap=�  $	9 200 $6 Perk2��( �� *sPerk2+* �� ". ��.��� + � ��$
, Wrap=�  $	9 200 $6 Perk3��( �� *sPerk3+* �� ". ��.��� + � ��$
, Wrap=�  $	9 200 $6 Perk4��( �� *sPerk4+* �� ". ��.��� + � ��$
, Wrap=�  $	9 200 $6 Perk5��( �� *sPerk5+* �� ". ��.��� + � ��$
, Wrap=�- �� ".  .��� + � ��$, 0,0,0,3q��� + � ��#, [ =   ColumnHeaderStyle= �� ". 
 .��� + � ��#, [ �� -   $��Button��$
��Left=�$��564,735,0,0q�$��1��$��76��$��20��$	��Top=��� -   > ��Name$> 	txtPlayer��$
��Left=�$��23��$��
469,10,0,0q�$��1��? �� TextWrapping$
? Wrap=�$��EPIC username��$	��Top=�$	��141���� -   @ ��Name$@ butLoad��$
��Load��$
��Left=�$��
615,10,0,0q�$��1��$	��Top=�$��75��$��23��