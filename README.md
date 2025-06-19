## 🔑 SSH-ключ для доступу до приватних пакетів Unity

окремо надаю SSH-ключ `id_unity_deploy`, який потрібен для завантаження приватних Git-пакетів у Unity через `manifest.json`.
### 🔧 Як налаштувати

#### 1. Скопіюйте ключ до вашої SSH-папки:
**Linux/macOS:**
```bash
mkdir -p ~/.ssh
cp ./id_unity_deploy ~/.ssh/
chmod 600 ~/.ssh/id_unity_deploy
```
**Windows:**
Скопіюйте файл `id_unity_deploy` у:
```
C:\Users\<Ваш_Користувач>\.ssh\
```

#### 2. Додайте або створіть файл `~/.ssh/config` з таким вмістом:
```ssh
Host github.com
  HostName github.com
  User git
  IdentityFile ~/.ssh/id_unity_deploy
```
#### 3. Перевірте з'єднання:
```bash
ssh -T git@github.com
```
✅ Якщо все добре, з'явиться повідомлення:
```
Hi your-username! You've successfully authenticated...
```
Після цього Unity зможе автоматично завантажувати всі залежності з приватних репозиторіїв, прописані у `manifest.json`.
