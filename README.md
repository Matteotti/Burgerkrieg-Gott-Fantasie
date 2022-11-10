# Burgerkrieg-Gott-Fantasie
Course project of ZJU Computer Game Programming Design :)

version 2022.11.10.2, latest edit: yyz

我把一些脚本的名字改了（比如那个在编辑器运行的脚本改成了update什么什么的），想到时候把所有需要编辑时更新的东西都写进去   
动态更改mesh已经完成，方法是挂载meshRenderer和meshFilter，然后更改meshFilter里的mesh值即可   
正在完善函数   
需要讨论和完善的：    
   
如何高亮？需要什么效果？   
    
需要做哪些元素反应？机制是什么呢？   
     
棋子站在格子上的时候地图块需要做些什么？传递元素？
棋子与格子交互的时候需要做什么？特殊格子传递效果？
这一部分好像需要与人物组对接   

鼠标点击格子的时候需要干什么呢？   
   
UpdateCell函数也需要更改格子的特效与粒子系统，需要完善

另外我们的格子排布方式改变了，所以WorldPosToHexPos和HexPosToWorldPos需要修改一下，因为我不知道是怎么排布的，所以可能得你来写一下这两个函数
   
正在解决：     
如何高亮？需要什么效果？  暂时想着用边缘高亮     
-------    
更新，边缘高亮已解决，现在可以让鼠标检测到的格子高亮了，但是插件只支持自定义三个颜色，准备自己改改   
