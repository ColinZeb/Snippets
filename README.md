# Oh My Zsh

```zsh
sudo apt install zsh
sh -c "$(curl -fsSL https://raw.github.com/ohmyzsh/ohmyzsh/master/tools/install.sh)"

git clone -b zsh https://github.com/ColinZeb/Snippets.git $ZSH_CUSTOM/plugins/Snippets 
echo . $ZSH_CUSTOM/plugins/Snippets/AppendZshrc.sh >>~/.zshrc
```

``` zsh
curl https://get.acme.sh | sh

mv .acme.sh/account.conf .acme.sh/account.conf.bak
cat $ZSH_CUSTOM/plugins/Snippets/acc.conf .acme.sh/account.conf
```
