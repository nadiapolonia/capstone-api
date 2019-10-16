docker build -t  tranquil-health-image .

docker tag  tranquil-health-image registry.heroku.com/tranquil-health/web

docker push registry.heroku.com/tranquil-health/web

heroku container:release web -a  tranquil-health
