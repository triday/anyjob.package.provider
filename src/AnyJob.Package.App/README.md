## How to use

```sh
docker run -p 80:80 -v {your-local-packs-root-dir}:/anyjob/packs anyjob/anyjob-file-provider
```
`your-local-packs-root-dir` must be a valid package folder. The structure like as below.
```
├─example
  ├─0.0.1
    ├─add.action
    ├─add.py
    ├─hello.action
    ├─hello.py
```
Then you can curl the address `http://{your-ip}/packages/all` to verify it.