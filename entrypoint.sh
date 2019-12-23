set -e
run_cmd='dotnet PWRSyllabus.API.dll'
until dotnet-ef database update --project PWRSyllabus.API/PWRSyllabus.API.csproj; do
>&2 echo "SQL Server is starting up"
sleep 1
done
>&2 echo "SQL Server is up - executing command"
cd app
exec $run_cmd
