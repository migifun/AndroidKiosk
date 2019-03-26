# AndroidKiosk
UnityでAndroidキオスクアプリを書き出したいとき用。
ナビゲーションバーを無効にするだけの簡易版です。

- Assets/Plugins/Android/ に AdminReceiver.java を作る
- Export Projectにチェック、Exportボタンで書き出し
- 書き出したAndroidManifest.xmlを Assets/Plugins/Android/ にコピペ
- AndroidManifest.xmlにReceiverタグ追加（applicationタグ内）
- receiver android:name に 作ったクラスを指定
- Assets/Plugins/Android/res/xml/ ディレクトリを作って admin.xml を新規作成
- Androidタブレットを初期化（設定>システム>リセット>データの初期化）
- 初期設定はできるだけスルー
- 開発者モードにして、USBデバッグだけONに
- UnityからUSB経由でアプリを書き出し
- ターミナルからadbコマンドでオーナー権限になる
```
adb shell dpm set-device-owner com.migifun.app.AndroidKiosk/.AdminReceiver
```
- UnityPlayerActivityを継承したjavaクラスを Assets/Plugins/Android/ に作る
- UnityからjavaのstartLockTask、stopLockTaskを実行する
- この時点でUnityにアプリを書き出すといけた。
- startLockTaskで、Pinningではなく、アプリが落とせない状況（ホームボタンなど消える）になる
- stopLockTaskで、解除