# Burgerkrieg-Gott-Fantasie
Course project of ZJU Computer Game Programming Design :)

version 2022.11.6.1, latest edit: gtz

新的框架

现在修改六边形坐标会直接反映在世界坐标的变化

现在地图是躺着的了

只会用预制体...

精灵没有同步到新的框架（没时间写了），所以运行时什么都看不到

HexCell - 对应原本的 MapGrid 和 MapGridBase

HexCoord - 控制单元格大小和位置，单独摘出。和HexCell一起使用

HexGrid- 对应原本的Map.cs。WARNING：这个没怎么修改，现在仅仅是能跑

Maps - 对应原本的 MapManager.cs（担心重名所以改了名）。WARNING：同上
