# simple-RC4

ð½ð½ð½ RC4æå·ã¢ã«ã´ãªãºã ãC#ã§å®è£ãã¦ã¿ãï¼  

![ææç©](./docs/img/fruit.png)  

## å®è¡æ¹æ³

```shell
dotnet run --project ./src --key "æå·åã­ã¼" --message "ã¡ãã»ã¼ã¸"
```

ä¾ãã°ããã  

```shell
dotnet run --project ./src --key "HappyNewYear" --message "Hello World!!!"

original: Hello World!!!
encrypt: PHNPdryKIQ1Kp4gmZCQ=
decrypt: Hello World!!!
```

æ­£ããæå·åã»å¾©å·åã§ãã¦ãããã¨ãç¢ºèªã§ãã¾ãã  

GitHub Actionsã§ãå®è¡ãã¦ãã¾ãã  
`./.github/workflows/run.yml`ã®`dotnet-run`ã¸ã§ãåã®`Run`ã¹ããããåç§ãã¦ãã ããã  

---

ãã¹ãããã«ã¯ããã  

```shell
dotnet test ./Tests
```
