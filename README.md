# 360GMAO

> Projet de GMAO (Gestion de Maintenance Assistée par Ordinateur) basé sur .NET 8, Clean Architecture, Angular, et Ionic.

## 🌐 Branchement Git

Ce projet utilise `main` comme branche principale (et non `master`).

Merci de configurer tous les outils CI/CD, Codex, ou pipelines en tenant compte de cela :

```bash
git checkout main
git push origin main
```

Si un outil attend une branche `master`, pensez à remplacer la référence `refs/heads/master` par `refs/heads/main`.

## 🚀 Prochaines étapes Codex

Vous pouvez charger le cahier des charges complet depuis le fichier `Cahier Charges Gmao Enrichi.md` et démarrer la génération de l’architecture Clean Architecture en .NET 8 avec TDD.

Commencez par :
- Proposer la structure de dossier pour le backend
- Générer les entités de domaine et leurs value objects
- Implémenter les tests xUnit liés

## ⚡ Stack Technique

- .NET 8
- Angular
- Ionic Angular (PWA)
- SQL Server
- EF Core / CQRS / MediatR / FluentValidation
- Docker / CI GitHub Actions
- Authentification JWT + Identity

---

Ce projet est supervisé par AmineDNET pour un déploiement GMAO multi-sites et scalable.
